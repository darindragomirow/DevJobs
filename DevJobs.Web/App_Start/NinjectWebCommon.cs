[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(DevJobs.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(DevJobs.Web.App_Start.NinjectWebCommon), "Stop")]

namespace DevJobs.Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Extensions.Conventions;
    using DevJobs.Data.Repositories;
    using System.Data.Entity;
    using DevJobs.Data;
    using DevJobs.Servicess.Contracts;
    using AutoMapper;
    using DevJobs.Data.SaveContext;
    using DevJobs.Web.Contracts;
    using DevJobs.Web.Contracts.Identity;
    using DevJobs.Web.Identity;
    using DevJobs.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel Kernel { get; private set; }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            Kernel = kernel;
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IService))
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });


            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind(typeof(DbContext), typeof(MsSqlDbContext)).To<MsSqlDbContext>().InRequestScope();
            kernel.Bind<ISaveContext>().To<SaveContext>();
            kernel.Bind<IMapper>().ToMethod(x => Mapper.Instance);

            // Identity
            kernel.Bind<IUserStore<User>>().To<UserStore<User>>().InRequestScope();
            //kernel.Bind<IApplicationUserManager>().To<ApplicationUserManager>().InRequestScope();
            //kernel.Bind<IApplicationSignInManager>().To<ApplicationSignInManager>().InRequestScope();
            kernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            //kernel.Bind<IMapper>().To<Mapper>().InSingletonScope();
            //kernel.Bind<IAdService>().To<AdService>().InSingletonScope();
            //kernel.Bind<ICityService>().To<CityService>().InSingletonScope();


        }
    }
}
