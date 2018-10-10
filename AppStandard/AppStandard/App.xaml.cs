using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
using AppStandard.Interfaces;
using AppStandard.Services;
using FreshMvvm;
using Plugin.MediaManager.Forms;
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
            // Make sure it doesn't get stripped away by the linker
            var workaround = typeof(VideoView);

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
