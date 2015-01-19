using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace MassivePixel.Common.Mvvm
{
    public class ViewModelLocatorBase<TLocator>
        where TLocator : ViewModelLocatorBase<TLocator>, new()
    {
        #region Singleton instance
        private static TLocator _instance;

        public static TLocator Instance
        {
            get { return _instance = _instance ?? new TLocator(); }
        }
        #endregion

        public ViewModelLocatorBase()
        {
            // When using WP this instance might be created in App.xaml
            _instance = _instance ?? this as TLocator;

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }
    }
}
