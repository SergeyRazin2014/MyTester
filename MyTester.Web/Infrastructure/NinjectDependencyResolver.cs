using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTester.Models;
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
            _kernel.Bind<ITestRepo>().To<TestRepo>();
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