using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Web.Common;
using System.Web.Mvc;
using WeatherForecast.Services;
using WeatherForecast.Context;
using WeatherForecast.Models;

namespace WeatherForecast.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IWeatherForecastProvider>().To<WeatherForecastProvider>();
            _kernel.Bind<IRepository<SavedCity>>().To<WeatherRepository>();
            _kernel.Bind<ICityLogRepository>().To<CityLogRepository>();
        }
    }
}
