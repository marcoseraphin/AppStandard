using System;

namespace AppStandard.Interfaces
{
    public interface ILocale
    {
        string GetCurrent();
        void SetLocale();
    }
}
