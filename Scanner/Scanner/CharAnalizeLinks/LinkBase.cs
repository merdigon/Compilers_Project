using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scanner.CharAnalizeLinks
{
    public class LinkBase
    {
        LinkBase Next { get; set; }

        Scanner Scanner { get; set; }

        public LinkBase(Scanner scanner)
        {
            this.Scanner = scanner;
        }

        public void SetScanner(Scanner scanner)
        {
            this.Scanner = scanner;
        }

        public virtual Token GetRequest(Token tempToken, char charac)
        {
            if (Next != null)
            {
                return Next.GetRequest(tempToken, charac);
            }
            else
            {
                throw new Exception("Brak obsługi");
            }
        }

        public void RegisterNext(LinkBase nextLink)
        {
            if (Next != null)
            {
                Next.RegisterNext(nextLink);
            }
            else
            {
                nextLink.SetScanner(Scanner);
                Next = nextLink;
            }
        }

        public void AddToken(Token token)
        {
            Scanner.AddToken(token);
        }
    }
}
