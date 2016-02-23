using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Abstract;
using DAL.Repositories;
using MyTester.DAL;
using Ninject;

namespace MyTester.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel) 
        {
            this._kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            _kernel.Bind<MyContext>().ToSelf().WithConstructorArgument("connectionString", ConfigurationManager.ConnectionStrings[0].ConnectionString);
            _kernel.Bind<IQueryRepo>().To<QueryRepo>();
            _kernel.Bind<IPersonRepo>().To<PersonRepo>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}