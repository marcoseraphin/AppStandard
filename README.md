# AppStandard
Default Start Xamarin.Forms Project with FreshMVVM (.Net Standard 2.0)

Includes:

- offline Realm Database
- multi language support
- using service based architecture with IoC and DIP (service interface injection)
- Xamarin.Essentials
- three sample Pages (Start Page, EditPage and Settings)
- Tabbed Based or MasterDetail preperation
- sample Page navigation using MVVM FrameWork with page parameter
- New Master/Detail-Container (AppStandardFreshMasterDetailNavigationContainer)

## Changelog

**2nd February 2020**

Apart from updating NuGet packages I wrote a new FreshMasterDetailNavigationContainer which is based upon it but has the possibility to add a AppStandardNavMenuItem with not only a page name but also an icon. Apart from that I did a little workaround to deselect a clicked item automatically instead keeping the ugly orange backgrounded item selected.
