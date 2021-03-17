using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using SmartStore.Core.Data;
using SmartStore.Core.Infrastructure;
using SmartStore.Core.Infrastructure.DependencyManagement;
using SmartStore.Data;
using SmartStore.AndMore.Data;
using SmartStore.AndMore.Domain;
using SmartStore.AndMore.Services;
using SmartStore.AndMore.Filters;
using SmartStore.Web.Controllers;

namespace SmartStore.AndMore
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            builder.RegisterType<SmartStoreAndMoreService>().As<ISmartStoreAndMoreService>().InstancePerRequest();

            //register named context
            builder.Register<IDbContext>(c => new SmartStoreAndMoreObjectContext(DataSettings.Current.DataConnectionString))
                .Named<IDbContext>(SmartStoreAndMoreObjectContext.ALIASKEY)
                .InstancePerRequest();

            builder.Register(c => new SmartStoreAndMoreObjectContext(DataSettings.Current.DataConnectionString))
                .InstancePerRequest();

            //override required repository with our custom context
            builder.RegisterType<EfRepository<SmartStoreAndMoreRecord>>()
                .As<IRepository<SmartStoreAndMoreRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(SmartStoreAndMoreObjectContext.ALIASKEY))
                .InstancePerRequest();

            builder.RegisterType<SampleActionFilter>()
                .AsActionFilterFor<ProductController>(x => x.ProductDetails(default(int), default(string), null))
                .InstancePerRequest();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
