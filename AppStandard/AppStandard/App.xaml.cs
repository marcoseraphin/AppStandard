using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using AppStandard.Interfaces;
using AppStandard.Services;
using FreshMvvm;
using Xamarin.Forms;

namespace AppStandard
{
	public partial class App : Application
	{
        /// <summary>
        /// Language type
        /// </summary>
        public enum LanguageType
        {
            NotSet = 0,
            German = 1,
            English = 2
        };

        /// <summary>
        /// App language
        /// </summary>
        public static LanguageType Language;

		public App ()
		{
			InitializeComponent();

            // Setup the IoC Container
            this.SetupIoC();

            // Init static localization table
            TranslationTables.InitStaticValues();

            // Show start page
            SetupPages(0);
		}

        /// <summary>
        /// Setup the pages
        /// </summary>
        /// <param name="tabpage">Tabpage.</param>
        public static void SetupPages(int tabpage)
        {
            var tabbedNavigation = new FreshTabbedNavigationContainer();

            // Tabbed Based 
            // =============
            tabbedNavigation.AddTab<StartPageModel>("Home", "tab_home3.png");
            tabbedNavigation.AddTab<SettingsPageModel>("Settings", "tab_settings.png");
            Application.Current.MainPage = tabbedNavigation;
            tabbedNavigation.SelectedItem = tabbedNavigation.Children[tabpage];

            // Master Detail Based
            // ===================
            //var masterDetailNav = new FreshMasterDetailNavigationContainer();
            //masterDetailNav.Init("Menu");
            //masterDetailNav.AddPage<StartPageModel>("Start", null);
            //masterDetailNav.AddPage<SettingsPageModel>("Settings", null);
            //Application.Current.MainPage = masterDetailNav;

        }

        /// <summary>
        /// Setup the IoC Container
        /// </summary>
        private void SetupIoC()
        {
            //FreshIOC.Container.Register<IDatabase, MemoryDatabaseService>().AsSingleton();
            FreshIOC.Container.Register<IDatabase, RealmDatabaseService>().AsSingleton();
            FreshIOC.Container.Register<IUserDialogs>(UserDialogs.Instance);

            //string connectionString = @"Data Source=10.211.55.6;Initial Catalog=DemoDB;Persist Security Info=True;User ID=dbadmin;Password=dbadmin";
            //string databaseTable = "Person";
            //string referenceName = "Marco";
            //string selectQuery = String.Format("SELECT * FROM {0} WHERE Name = '{1}' ", databaseTable, referenceName);
            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        //open connection
            //        connection.Open();

            //        SqlCommand command = new SqlCommand(selectQuery, connection)
            //        {
            //            Connection = connection,
            //            CommandText = selectQuery
            //        };

            //        var dataReader = command.ExecuteReader();

            //        //check if account exists
            //        var exists = dataReader.HasRows;

            //        if (exists)
            //        {
            //            while (dataReader.Read())
            //            {
            //                int pkID = dataReader.GetInt32(0);
            //                string Name = dataReader.GetString(1);
            //                int Age = dataReader.GetInt32(2);
            //            }
            //        }
            //    }
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine("Error " + exception.Message);
            //}
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
