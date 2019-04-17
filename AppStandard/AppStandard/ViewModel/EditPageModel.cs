using AppStandard.Interfaces;
using FreshMvvm;
using Xamarin.Forms;

namespace AppStandard
{
    public class EditPageModel : FreshBasePageModel
    {
        /// <summary>
        /// The database service.
        /// </summary>
        private IDatabase databaseService;

        /// <summary>
        /// The first name label.
        /// </summary>
        private string firstNameLabel;
        public string FirstNameLabel
        {
            get
            {
                return this.firstNameLabel;
            }
            set
            {
                this.firstNameLabel = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The edited first name entry
        /// </summary>
        private string editFirstName;
        public string EditFirstName
        {
            get
            {
                return this.editFirstName;
            }
            set
            {
                this.editFirstName = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <value>The save command.</value>
        public Command SaveCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await CoreMethods.PopPageModel(this.EditFirstName, false, true);
                }
                );
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:AppStandard.ViewModel.EditPageModel"/> class.
        /// </summary>
        /// <param name="database">Database.</param>
        public EditPageModel(IDatabase database)
        {
            this.databaseService = database;
        }
         
        /// <summary>
        /// Init the specified initData.
        /// </summary>
        /// <param name="initData">Init data.</param>
        public override void Init(object initData)
        {

            base.Init(initData);

            // Get the first name from StartPage for editing
            this.EditFirstName = initData.ToString();

            // Alternatively (to the page parameter) get the First Name field from the database
            var firstNameFromDB = this.databaseService.ReadDBValue("FirstName");
        }
    }


}
