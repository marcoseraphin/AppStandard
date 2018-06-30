using System;
using System.Collections.Generic;
using System.Text;
using AppStandard.Interfaces;

namespace AppStandard.Services
{
    public class MemoryDatabaseService : IDatabase
    {
        private Dictionary<string, string> Storage = new Dictionary<string, string>();

        public MemoryDatabaseService()
        {
        }

        public string ReadDBValue(string key)
        {
            if (this.Storage.ContainsKey(key) == true)
            {
                return this.Storage[key];
            }

            return String.Empty;
        }

        public bool SaveDBValue(string key, string value)
        {
            if (this.Storage.ContainsKey(key) == true)
            {
                this.Storage[key] = value;
            }
            else
            {
                this.Storage.Add(key, value);
            }

            return true;
        }

        public bool UpdateDBValue(string key, string value)
        {
            if (this.Storage.ContainsKey(key) == true)
            {
                this.Storage[key] = value;
                return true;
            }
            else
            {
                this.SaveDBValue(key, value);
            }

            return false;
        }

        public bool DeleteDBValue(string key)
        {
            if (this.Storage.ContainsKey(key) == true)
            {
                this.Storage.Remove(key);
                return true;
            }

            return false;
        }

        public Dictionary<string, string> ReadTranslationValues(string locale)
        {
            return new Dictionary<string, string>();
        }
    }
}
