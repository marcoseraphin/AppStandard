using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppStandard.Interfaces;
using AppStandard.Model;
using Realms;

namespace AppStandard.Services
{
    public class RealmDatabaseService : IDatabase
    {
        /// <summary>
        /// The realm db.
        /// </summary>
        private Realm realmDB = Realm.GetInstance();

        /// <summary>
        /// Reads the DB Value.
        /// </summary>
        /// <returns>The DBV alue.</returns>
        /// <param name="key">Key.</param>
        public string ReadDBValue(string key)
        {
            var valueObject = (from k in realmDB.All<DBSettingsObjekt>()
                               where k.Key == key
                               select k).ToList();

            if (valueObject.Count > 0)
            {
                return valueObject.First().Value;
            }

            return String.Empty;
        }

        //public (string First, string Last) GetName(int index)
        //{
        //    var first = "Marco";
        //    var last = "Seraphin";

        //    return (first, last);
        //}

        /// <summary>
        /// Saves the DB Value.
        /// </summary>
        /// <returns><c>true</c>, if DB Value was saved, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public bool SaveDBValue(string key, string value)
        {
            try
            {
                realmDB.Write(() =>
                {
                    //DBSettingsObjekt settingsObject = realmDB.CreateObject("DBSettingsObjekt"); // <DBSettingsObjekt>();
                    //settingsObject.Key = key;
                    //settingsObject.Value = value;

                    DBSettingsObjekt settingsObject = new DBSettingsObjekt();
                    settingsObject.Key = key;
                    settingsObject.Value = value;
                    realmDB.Add(settingsObject);

                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the value.
        /// </summary>
        /// <returns><c>true</c>, if value was updated, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        /// <param name="value">Value.</param>
        public bool UpdateDBValue(string key, string value)
        {
            try
            {
                var valueObject = (from k in realmDB.All<DBSettingsObjekt>()
                                   where k.Key == key
                                   select k);

                if (valueObject.Any())
                {
                    if (valueObject != null)
                    {
                        using (var trans = realmDB.BeginWrite())
                        {
                            valueObject.First().Value = value;
                            trans.Commit();

                            return true;
                        }
                    }
                }
                else
                {
                    this.SaveDBValue(key, value);
                    return true;
                }

                return false;

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes the value.
        /// </summary>
        /// <returns><c>true</c>, if value was deleted, <c>false</c> otherwise.</returns>
        /// <param name="key">Key.</param>
        public bool DeleteDBValue(string key)
        {
            try
            {
                var valueObject = (from k in realmDB.All<DBSettingsObjekt>()
                                   where k.Key == key
                                   select k);

                if (valueObject.Any())
                {
                    if (valueObject != null)
                    {
                        using (var trans = realmDB.BeginWrite())
                        {
                            realmDB.Remove(valueObject.First());
                            trans.Commit();

                            return true;
                        }
                    }
                }
                else
                {
                    return false;
                }

                return false;

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Reads the translation values.
        /// </summary>
        /// <returns>The translation values.</returns>
        /// <param name="locale">Locale.</param>
        public Dictionary<string, string> ReadTranslationValues(string locale)
        {
            Dictionary<string, string> resultDict = new Dictionary<string, string>();


            var translationValues = (from k in realmDB.All<DBSettingsObjekt>()
                                     where k.Key.StartsWith(locale)
                                     select k).ToList();

            if (translationValues.Count > 0)
            {
                foreach (var translationValue in translationValues)
                {
                    resultDict.Add(translationValue.Key, translationValue.Value);
                }
            }

            return resultDict;

        }

    }

}
