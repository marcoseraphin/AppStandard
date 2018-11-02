using System;
using AppStandard.Interfaces;
using FreshMvvm;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace AppStandard
{
    public class StartPageModel : FreshBasePageModel
    {

        private IDatabase databaseService;

        public StartPageModel(IDatabase database)
        {
            this.databaseService = database;
        }
    }
}
