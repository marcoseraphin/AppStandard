using System;
using System.Collections.Generic;
using AppStandard.Interfaces;
using FreshMvvm;
using Xamarin.Forms;

namespace AppStandard
{
    public class SettingsPageModel : FreshBasePageModel
    {
        /// <summary>
        /// The database service.
        /// </summary>
        private IDatabase databaseService;

        /// <summary>
        /// The language list.
        /// </summary>
        private List<string> languageList = new List<string>()
            {
                "Deutsch",
                "English"
            };

        /// <summary>
        /// Gets the language list.
        /// </summary>
        /// <value>The language list.</value>
        public List<string> LanguageList => languageList;

        /// <summary>
        /// The selected language.
        /// </summary>
        private string selectedLanguage;
        public string SelectedLanguage
        {
            get
            {
                return this.selectedLanguage;
            }
            set
            {
                if (this.selectedLanguage != value)
                {
                    this.selectedLanguage = value;

                    if (value == "Deutsch")
                    {
                        App.Language = App.LanguageType.German;
                        databaseService.UpdateDBValue("AppLanguage", "German");
                    }
                    else
                    {
                        App.Language = App.LanguageType.English;
                        databaseService.UpdateDBValue("AppLanguage", "English");
                    }

                    // Init static localization table
                    TranslationTables.SetInitialValues();
                    App.SetupPages(1);

                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppStandard.SettingsPageModel"/> class.
        /// </summary>
        /// <param name="databaseService">Database service.</param>
        public SettingsPageModel(IDatabase databaseService)
        {
           this.databaseService = databaseService;

            if (App.Language == App.LanguageType.German)
            {
                this.selectedLanguage = "Deutsch";
                this.SelectedLanguage = "Deutsch";
            }
            else
            {
                this.selectedLanguage = "English";
                this.SelectedLanguage = "English";
            }
        }
    }
}
