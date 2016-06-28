using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DependencyResolver;
using Ninject;

using Blog.Models;
using Blog.BLL.Interface.Services;
using System.Web.Security;
using Blog.Providers;
using Blog.Mappers;
using Blog.BLL.Services;

namespace Blog.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;            
            kernel.ConfigurateResolverWeb();
        }
        public object GetService(Type serviceType)
        
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        
    }
}