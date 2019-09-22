using Doggis.Data.UnitOfWork;
using Doggis.Services;
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
            kernel.Bind<ILoginService>().To<LoginService>();
            kernel.Bind<IHomeService>().To<HomeService>();
            kernel.Bind<IVeterinaryService>().To<VeterinaryService>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}