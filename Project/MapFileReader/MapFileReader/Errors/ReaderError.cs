using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Errors
{
    [DataContract]
    public class ReaderError
    {
        [DataMember]
        public ReaderErrorsType ErrorType
        {
            get
            {
                return _errorType;
            }
            set
            {
                _errorType = value;
            }
        }

        [DataMember]
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        [DataMember]
        public string AdditionalInfo
        {
            get
            {
                return _additionalInfo;
            }
            set
            {
                _additionalInfo = value;
            }
        }

        private string _value;

        private ReaderErrorsType _errorType;

        private string _additionalInfo;

        public ReaderError(Token token){
            this._errorType = ReaderErrorsType.SCANNER;

            if(token == null)
                return;

            this._value = token.Value;
            this._additionalInfo = token.AdditionalInfo;
        }

        public ReaderError(string value, ReaderErrorsType errorType)
        {
            this._errorType = errorType;
            this._value = value;
        }

        public ReaderError(string value, string additionalInfo, ReaderErrorsType errorType)
        {
            this._errorType = errorType;
            this._additionalInfo = additionalInfo;
            this._value = value;
        }

        public override string ToString()
        {
            return string.Format("[{0}_ERROR]: {1} -> {2}", ErrorType.ToString(), Value, AdditionalInfo);
        }
    }
}
