using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Web.Common;
using System.Data.Entity;

using Blog.BLL.Services;
using Blog.BLL.Interface.Services;
using Blog.DAL.Interface.Interface;
using DAL.Concrete;
using ORM;


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
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<BlogModel>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<BlogModel>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IRoleUserService>().To<RoleUserService>();
            kernel.Bind<IRoleUserRepository>().To<RoleUserRepository>();
            kernel.Bind<ISectionService>().To<SectionService>();
            kernel.Bind<ISectionRepository>().To<SectionRepository>();
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<IArticleRepository>().To<ArticleRepository>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<ICommentRepository>().To<CommentRepository>();
            kernel.Bind<IMarkerService>().To<MarkerService>();
            kernel.Bind<IMarkerRepository>().To<MarkerRepository>();
            kernel.Bind<ITagService>().To<TagService>();
            kernel.Bind<ITagRepository>().To<TagRepository>();
            kernel.Bind<ITagArticleService>().To<TagArticleService>();
            kernel.Bind<ITagArticleRepository>().To<TagAtricleRepository>();
        }


    }
}
