using System.Data.Entity;
using BLLInterface.Services;
using BLL.Services;
using DAL.Concrete;
using DALInterface.Repository;
using Ninject;
using Ninject.Web.Common;
using ORM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DependencyResolver
{
    public static class ResolverConfig 
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
          
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind<DbContext>().To<EntityModel>().InRequestScope();
          
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleServices>();
            kernel.Bind<ILotService>().To<LotServices>();
            kernel.Bind<IAuctionService>().To<AuctionService>();
            kernel.Bind<IFeedbackServise>().To<IFeedbackServise>();
            kernel.Bind<IRateService>().To<RateService>();

        }
    }
}
