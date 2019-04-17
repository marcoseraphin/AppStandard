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
        /// <summary>
        /// The database service.
        /// </summary>
        private readonly IDatabase databaseService;

        /// <summary>
        /// The first name.
        /// </summary>
        private string firstName;
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                RaisePropertyChanged();
            }
        }



        /// <summary>
        /// Gets the edit command.
        /// </summary>
        /// <value>The edit command.</value>
        public Command EditCommand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        await CoreMethods.PushPageModel<EditPageModel>(this.FirstName, false, true);
                    }
                    catch (Exception ex)
                    {

                    }

                }
                );
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppStandard.StartPageModel"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        public StartPageModel(IDatabase database)
        {
            this.databaseService = database;
            this.FirstName = "Boris Becker";
        }

        /// <summary>
        /// Reverses the init.
        /// </summary>
        /// <param name="returnedData">Returned data.</param>
        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);

            // Get the edited first name from EditPage
            this.FirstName = returnedData.ToString();

            // Alternatively (to the page parameter) save the First Name field to the database
            this.databaseService.UpdateDBValue("FirstName", this.FirstName);
        }
    }
}
