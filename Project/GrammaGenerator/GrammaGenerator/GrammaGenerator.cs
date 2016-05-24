using MapFileReader.Attributes;
using MapFileReader.KMLObjects;
using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrammaGenerator
{
    class GrammaGenerator
    {
        public StringBuilder CreateGramma()
        {
            return new StringBuilder(CreateTokenList().ToString() + CreateProductionList().ToString());
        }

        private StringBuilder CreateTokenList()
        {
            List<TokenDictionary> tokenList = new List<TokenDictionary>();

            Assembly myAssembly = Assembly.GetAssembly(typeof(KMLBase));
            Type[] kmlTypes = myAssembly.ManifestModule.GetTypes().Where(p => p.Namespace.EndsWith("KMLObjects")).ToArray();

            foreach (Type type in kmlTypes)
            {
                //jeżeli klasa nie ma atrybutu oznaczającego klasy pliku KML
                if (type.GetCustomAttributes(true).Where(p => p is KMLMarkClassAttribute).FirstOrDefault() == null)
                    continue;

                foreach (PropertyInfo pinfo in type.GetProperties())
                {
                    KMLMarkNameAttribute kmlAtribute = (KMLMarkNameAttribute)((object[])pinfo.GetCustomAttributes(true)).Where(p => p is KMLMarkNameAttribute).FirstOrDefault();
                    if (kmlAtribute != null)
                    {
                        if (!tokenList.Select(p => p.Value).Contains(kmlAtribute.Name+"_V") && !tokenList.Select(p => p.Value).Contains(kmlAtribute.Name+"_O"))
                        {
                            if (pinfo.PropertyType.BaseType == typeof(KMLBase))
                            {
                                tokenList.Add(new TokenDictionary(kmlAtribute.Name.ToUpper() + "_O"));
                                tokenList.Add(new TokenDictionary(kmlAtribute.Name.ToUpper() + "_C"));
                            }
                            else
                                tokenList.Add(new TokenDictionary(kmlAtribute.Name.ToUpper() + "_V"));
                        }
                    }
                }
            }
            return TransformTokenDictionaryListIntoStringBuilder(tokenList);
        }

        private StringBuilder TransformTokenDictionaryListIntoStringBuilder(List<TokenDictionary> tokens)
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendLine("%tokens%");
            strBuild.AppendLine();
            tokens.ForEach(p => strBuild.AppendLine(p.Value + " = \"" + p.Value + "\""));
            strBuild.AppendLine();
            return strBuild;
        }

        private StringBuilder CreateProductionList()
        {
            StringBuilder globProd = new StringBuilder();
            globProd.AppendLine("%productions%");
            globProd.AppendLine();
            Stack<ProdNode> prodToDo = new Stack<ProdNode>();
            prodToDo.Push(new ProdNode(){ ProdName="PLACEMARK", ProdTokenType=typeof(PlacemarkKML) });

            while(prodToDo.Count > 0)
            {
                StringBuilder oneProd = new StringBuilder();
                ProdNode currProd = prodToDo.Pop();
                Type type = currProd.ProdTokenType;

                //jeżeli klasa nie ma atrybutu oznaczającego klasy pliku KML
                if (type.GetCustomAttributes(true).Where(p => p is KMLMarkClassAttribute).FirstOrDefault() == null)
                    continue;

                oneProd.Append(currProd.ProdName + "_PROD = " + currProd.ProdName + "_O ");

                foreach (PropertyInfo pinfo in type.GetProperties())
                {
                    KMLMarkNameAttribute kmlAtribute = (KMLMarkNameAttribute)((object[])pinfo.GetCustomAttributes(true)).Where(p => p is KMLMarkNameAttribute).FirstOrDefault();
                    if (kmlAtribute != null)
                    {
                        if (pinfo.PropertyType.BaseType == typeof(KMLBase))
                        {
                            oneProd.Append(kmlAtribute.Name.ToUpper() + "_PROD ");
                            prodToDo.Push(new ProdNode() { ProdName = kmlAtribute.Name.ToUpper(), ProdTokenType = pinfo.PropertyType });
                        }
                        else
                        {
                            if (pinfo.GetCustomAttributes(true).Where(p => p is KMLMarkOptionalAttribute).FirstOrDefault() == null)
                                oneProd.Append(kmlAtribute.Name.ToUpper() + "_V ");
                            else
                                oneProd.Append("[" + kmlAtribute.Name.ToUpper() + "_V] ");
                        }
                    }
                }
                oneProd.Append(currProd.ProdName + "_C ;");
                globProd.AppendLine(oneProd.ToString());
            }
            return globProd;
        }
    }

    public class ProdNode
    {
        public string ProdName { get; set; }
        public Type ProdTokenType { get; set; }
    }
}
