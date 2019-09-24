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
            kernel.Bind<IPetService>().To<PetService>();
            kernel.Bind<IServiceScheduleService>().To<ServiceScheduleService>();

            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}