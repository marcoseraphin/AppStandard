using System;
using System.Collections.Generic;
using AppStandard;
using AppStandard.Interfaces;
using FreshMvvm;

namespace AppStandard
{
    public class TranslationTables
    {
        /// <summary>
        /// The translation table.
        /// </summary>
        private static Dictionary<string, string> TranslationTable = new Dictionary<string, string>();

        /// <summary>
        /// Translate
        /// </summary>    
        public static string Translate(string elementName)
        {
            string result = "<TranslationNotFound>";

            string culture = "en-US"; // Default
            culture = App.Language == App.LanguageType.German ? "de-DE" : culture;

            if (TranslationTable.ContainsKey(culture + "#" + elementName) == true)
            {
                return TranslationTable[culture + "#" + elementName];
            }

            return result;
        }

        /// <summary>
        /// Inits the static values.
        /// </summary>
        public static void InitStaticValues()
        {
            // Sets the app language on device UI Language OR use saved DB language value
            SetAppLanguageOnDeviceUILanguageORLocalDBLanguageValue();

            bool translateTablesInDB = CheckTranslateTableInDB();
            translateTablesInDB = false; // During translation process set to false
            if (translateTablesInDB == false)
            {
                SetInitialValues();
                WriteTranslationTableToDB();
            }
            else
            {
                ReadTranslationTableFromDB();
            }

            // Set backend translation changes in memory dictionary and local DB
            GetTranslationChangesFromBackend();
        }

        /// <summary>
        /// Sets the initial values.
        /// </summary>
        public static void SetInitialValues()
        {
            TranslationTable.Clear();

            if (App.Language == App.LanguageType.German)
            {
                TranslationTable.Add("de-DE#" + "CaptionLabel", "Startseite");                                
            }

            if (App.Language == App.LanguageType.English)
            {
                TranslationTable.Add("en-US#" + "CaptionLabel", "Start Page");                                
            }
        }

        /// <summary>
        /// Checks the translate table in db.
        /// </summary>
        /// <returns><c>true</c>, if translate table in db was checked, <c>false</c> otherwise.</returns>
        private static bool CheckTranslateTableInDB()
        {
            bool result = false;

            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();
            string value = String.Empty;

            if (App.Language == App.LanguageType.German)
            {
                value = databaseService.ReadDBValue("de-DE#" + "LogInButton");
            }

            if (App.Language == App.LanguageType.English)
            {
                value = databaseService.ReadDBValue("en-US#" + "LogInButton");
            }

            result = value != String.Empty;

            return result;
        }

        /// <summary>
        /// Writes the translation table to db.
        /// </summary>
        private static void WriteTranslationTableToDB()
        {
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            foreach (var key in TranslationTable.Keys)
            {
                databaseService.UpdateDBValue(key, TranslationTable[key]);
            }
        }

        /// <summary>
        /// Gets the translation changes from backend.
        /// </summary>
        private static void GetTranslationChangesFromBackend()
        {
            // Here get backend changes
            Dictionary<string, string> translationTableChanges = new Dictionary<string, string>();
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            translationTableChanges.Add("de-DE#" + "WelcomeLabel", "Willkommen");

            // Set changes in memory dictionary and local DB
            foreach (var key in translationTableChanges.Keys)
            {
                if (TranslationTable.ContainsKey(key) == true)
                {
                    TranslationTable[key] = translationTableChanges[key];
                    databaseService.UpdateDBValue(key, translationTableChanges[key]);
                }
            }

        }

        /// <summary>
        /// Reads the translation table from db.
        /// </summary>
        private static void ReadTranslationTableFromDB()
        {
            string culture = "en-US"; // Default
            culture = App.Language == App.LanguageType.German ? "de-DE" : culture;
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            Dictionary<string, string> translationValues = databaseService.ReadTranslationValues(culture);

            TranslationTable.Clear();
            foreach (var translationValueKey in translationValues.Keys)
            {
                TranslationTable.Add(translationValueKey, translationValues[translationValueKey]);
            }
        } 

        /// <summary>
        /// Sets the app language on device UI Language OR use saved DB language value
        /// </summary>
        private static void SetAppLanguageOnDeviceUILanguageORLocalDBLanguageValue()
        {
            IDatabase databaseService = FreshIOC.Container.Resolve<IDatabase>();

            string readAppLanguage = databaseService.ReadDBValue("AppLanguage");
            if (readAppLanguage == "English")
            {
                App.Language = App.LanguageType.English;
            }

            if (readAppLanguage == "German")
            {
                App.Language = App.LanguageType.German;
            }

            //App.Language = App.LanguageType.NotSet;
            if (App.Language == App.LanguageType.NotSet)
            {
                // Set device UI language as default
                string locale = L10n.Locale();

                if ((locale.ToUpper().StartsWith("DE-", StringComparison.CurrentCulture) == true))
                {
                    App.Language = App.LanguageType.German;
                    databaseService.UpdateDBValue("AppLanguage", "German");
                }
                else
                {
                    App.Language = App.LanguageType.English;
                    databaseService.UpdateDBValue("AppLanguage", "English");
                }
            }
        }
    }

}

