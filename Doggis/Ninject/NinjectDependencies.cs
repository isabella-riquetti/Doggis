using Doggis.Data.UnitOfWork;
using Doggis.Services.ServiceService;
using Ninject;
using System.Web.Mvc;

namespace Doggis.Ninject
{
    public class NinjectDependencies
    {
        public static void ConfigureDependencies()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IServiceService>().To<ServiceService>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}