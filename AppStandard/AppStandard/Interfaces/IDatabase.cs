using System.Collections.Generic;

namespace AppStandard.Interfaces
{
    public interface IDatabase
    {
        string ReadDBValue(string key);
        bool SaveDBValue(string key, string value);
        bool UpdateDBValue(string key, string value);
        bool DeleteDBValue(string key);
        Dictionary<string, string> ReadTranslationValues(string locale);
    }
}