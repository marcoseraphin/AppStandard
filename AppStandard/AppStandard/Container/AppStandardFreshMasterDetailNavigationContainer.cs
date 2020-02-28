using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppStandard.Container
{
    /// <summary>
    /// Class representing a navigation Menu Item
    /// </summary>
    public class AppStandardNavMenuItem
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public AppStandardNavMenuItem(string name)
        {
            this.Name = name;
        }

        public AppStandardNavMenuItem(string name, string image)
        {
            this.Name = name;
            this.Image = image;
        }
    }

    /// <summary>
    /// Class based on FreshMasterDetailNavigationContainer offering menu icons and deselect of selected item
    /// </summary>
    public class AppStandardFreshMasterDetailNavigationContainer : Xamarin.Forms.MasterDetailPage, IFreshNavigationService
    {
        List<Page> _pagesInner = new List<Page>();
        Dictionary<string, Page> _pages = new Dictionary<string, Page>();
        ContentPage _menuPage;
        ObservableCollection<string> _pageNames = new ObservableCollection<string>();
        ListView _listView = new ListView()
        {
            Margin = new Thickness(5, 5, 5, 5)
        };
        ObservableCollection<AppStandardNavMenuItem> menuItems { get; set; } = new ObservableCollection<AppStandardNavMenuItem>();

        public Dictionary<string, Page> Pages { get { return _pages; } }
        protected ObservableCollection<string> PageNames { get { return _pageNames; } }

        public AppStandardFreshMasterDetailNavigationContainer() : this(Constants.DefaultNavigationServiceName)
        {
            this._listView.ItemTemplate = this.CreateListViewDataTemplate();
        }

        public AppStandardFreshMasterDetailNavigationContainer(string navigationServiceName)
        {
            NavigationServiceName = navigationServiceName;
            RegisterNavigation();
            this._listView.ItemTemplate = this.CreateListViewDataTemplate();
        }

        public void Init(string menuTitle, string menuIcon = null)
        {
            CreateMenuPage(menuTitle, menuIcon);
            RegisterNavigation();
            this._listView.ItemTemplate = this.CreateListViewDataTemplate();
        }

        protected virtual void RegisterNavigation()
        {
            FreshIOC.Container.Register<IFreshNavigationService>(this, NavigationServiceName);
        }

        public virtual void AddPage<T>(AppStandardNavMenuItem menuItem, object data = null) where T : FreshBasePageModel
        {
            var page = FreshPageModelResolver.ResolvePageModel<T>(data);
            page.GetModel().CurrentNavigationServiceName = NavigationServiceName;
            _pagesInner.Add(page);
            var navigationContainer = CreateContainerPage(page);
            _pages.Add(menuItem.Name, navigationContainer);
            menuItems.Add(menuItem);
            _pageNames.Add(menuItem.Name);
            if (_pages.Count == 1)
                Detail = navigationContainer;
        }

        public virtual void AddPage(string modelName, AppStandardNavMenuItem menuItem, object data = null)
        {
            var pageModelType = Type.GetType(modelName);
            var page = FreshPageModelResolver.ResolvePageModel(pageModelType, null);
            page.GetModel().CurrentNavigationServiceName = NavigationServiceName;
            _pagesInner.Add(page);
            var navigationContainer = CreateContainerPage(page);
            _pages.Add(menuItem.Name, navigationContainer);
            menuItems.Add(menuItem);
            _pageNames.Add(menuItem.Name);
            if (_pages.Count == 1)
                Detail = navigationContainer;
        }

        public DataTemplate CreateListViewDataTemplate()
        {
            return new DataTemplate(() =>
            {
                var image = new Image()
                {
                    HeightRequest = 32
                };
                image.SetBinding(Image.SourceProperty, new Binding("Image"));

                var lbName = new Label()
                {
                    HorizontalTextAlignment = TextAlignment.Start,
                    VerticalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(5, 0, 0, 0)
                };
                lbName.SetBinding(Label.TextProperty, new Binding("Name"));

                var content = new StackLayout
                {
                    Spacing = 2,
                    Padding = new Thickness(5, 5, 5, 5),
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Children =
                    {
                        image,
                        lbName
                    }
                };

                return new ViewCell()
                {
                    View = content
                };
            });
        }

        internal Page CreateContainerPageSafe(Page page)
        {
            if (page is NavigationPage || page is MasterDetailPage || page is TabbedPage)
                return page;

            return CreateContainerPage(page);
        }

        protected virtual Page CreateContainerPage(Page page)
        {
            return new NavigationPage(page);
        }

        protected virtual void CreateMenuPage(string menuPageTitle, string menuIcon = null)
        {
            _menuPage = new ContentPage();
            _menuPage.Title = menuPageTitle;

            _listView.ItemsSource = this.menuItems;

            _listView.ItemTapped += (sender, e) =>
            {
                if (_pages.ContainsKey(((AppStandardNavMenuItem)e.Item).Name))
                {
                    Detail = _pages[((AppStandardNavMenuItem)e.Item).Name];
                }

                IsPresented = false;

                ((ListView)sender).SelectedItem = null;
            };

            /*_listView.ItemSelected += (sender, args) =>
            {
                if (_pages.ContainsKey(((AppStandardNavMenuItem)args.SelectedItem).Name))
                {
                    Detail = _pages[((AppStandardNavMenuItem)args.SelectedItem).Name];
                }

                IsPresented = false;
            //};*/

            _menuPage.Content = _listView;

            var navPage = new NavigationPage(_menuPage) { Title = "Menu" };

            if (!string.IsNullOrEmpty(menuIcon))
                navPage.IconImageSource = menuIcon;

            Master = navPage;
        }

        public Task PushPage(Page page, FreshBasePageModel model, bool modal = false, bool animate = true)
        {
            if (modal)
                return Navigation.PushModalAsync(CreateContainerPageSafe(page));
            return (Detail as NavigationPage).PushAsync(page, animate); //TODO: make this better
        }

        public Task PopPage(bool modal = false, bool animate = true)
        {
            if (modal)
                return Navigation.PopModalAsync(animate);
            return (Detail as NavigationPage).PopAsync(animate); //TODO: make this better            
        }

        public Task PopToRoot(bool animate = true)
        {
            return (Detail as NavigationPage).PopToRootAsync(animate);
        }

        public string NavigationServiceName { get; private set; }

        public void NotifyChildrenPageWasPopped()
        {
            if (Master is NavigationPage)
                ((NavigationPage)Master).NotifyAllChildrenPopped();
            if (Master is IFreshNavigationService)
                ((IFreshNavigationService)Master).NotifyChildrenPageWasPopped();

            foreach (var page in this.Pages.Values)
            {
                if (page is NavigationPage)
                    ((NavigationPage)page).NotifyAllChildrenPopped();
                if (page is IFreshNavigationService)
                    ((IFreshNavigationService)page).NotifyChildrenPageWasPopped();
            }
            if (this.Pages != null && !this.Pages.ContainsValue(Detail) && Detail is NavigationPage)
                ((NavigationPage)Detail).NotifyAllChildrenPopped();
            if (this.Pages != null && !this.Pages.ContainsValue(Detail) && Detail is IFreshNavigationService)
                ((IFreshNavigationService)Detail).NotifyChildrenPageWasPopped();
        }

        public Task<FreshBasePageModel> SwitchSelectedRootPageModel<T>() where T : FreshBasePageModel
        {
            var tabIndex = _pagesInner.FindIndex(o => o.GetModel().GetType().FullName == typeof(T).FullName);

            _listView.SelectedItem = _pageNames[tabIndex];

            return Task.FromResult((Detail as NavigationPage).CurrentPage.GetModel());
        }
    }
}