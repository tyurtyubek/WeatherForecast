using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using WeatherForecastUWP.ViewModels;
using WeatherForecastUWP.Views;

namespace WeatherForecastUWP
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();

            navigationService.Configure(nameof(WeatherForecastViewModel), typeof(WeatherForecastView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
            }
            else
            {
            }

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<WeatherForecastViewModel>();

            ServiceLocator.Current.GetInstance<WeatherForecastViewModel>();
        }

        public WeatherForecastViewModel WeatherForecastVMInstance
        {
            get { return ServiceLocator.Current.GetInstance<WeatherForecastViewModel>(); }
        }
    }
}

