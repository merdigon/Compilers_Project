using MapFileReader.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapFileReader.Errors
{
    public class ReaderError
    {
        public ReaderErrorsType ErrorType
        {
            get
            {
                return _errorType;
            }
        }

        public string Value
        {
            get
            {
                return _value;
            }
        }

        public string AdditionalInfo
        {
            get
            {
                return _additionalInfo;
            }
        }

        private readonly string _value;

        private readonly ReaderErrorsType _errorType;

        private readonly string _additionalInfo;

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
