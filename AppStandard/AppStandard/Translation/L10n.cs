using AppStandard.Interfaces;
using Xamarin.Forms;

namespace AppStandard
{

    public class L10n
    {
        
        public static void SetLocale()
        {
            DependencyService.Get<ILocale>().SetLocale();
        }

        /// <remarks>
        /// Maybe we can cache this info rather than querying every time
        /// </remarks>
        public static string Locale()
        {
            return DependencyService.Get<ILocale>().GetCurrent();
        }

        /// <summary>
        /// Localize the specified key 
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="comment">Comment.</param>
        public static string Localize(string key, string comment)
        {
            //Debug.WriteLine("Localize " + key);
            string result = TranslationTables.Translate(key);
            return result;
        }
    }
}