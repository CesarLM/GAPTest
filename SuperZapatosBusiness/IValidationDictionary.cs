using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatosBusiness
{
    public partial interface IValidationDictionary
    {
        void AddError(string key, string errorMessage);
        //string GetError(string key, Enums.DictionaryReturnType returnType, string displayFormatString);
        //List<string> GetErrors(Enums.DictionaryReturnType returnType, string displayFormatString);
        void UpdateError(string key, string errorMessage);
        void DeleteError(string key);
        bool IsValid { get; }
    }
}


