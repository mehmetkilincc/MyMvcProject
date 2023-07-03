using MyMvcProject.Business.Abstract;
using MyMvcProject.Business.Concrete;
using MyMvcProject.DataAccess.Abstract;
using MyMvcProject.DataAccess.Concrete.EntityFramework;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MyMvcProject.UI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICategoryRepository, EfCategoryRepository>();

            container.RegisterType<IHeadingService, HeadingService>();
            container.RegisterType<IHeadingRepository, EfHeadingRepository>();

            container.RegisterType<IContentService, ContentService>();
            container.RegisterType<IContentRepository, EfContentRepository>();

            container.RegisterType<IAboutService, AboutService>();
            container.RegisterType<IAboutRepository, EfAboutRepository>();

            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IAdminRepository, EfAdminRepository>();

            container.RegisterType<IWriterService, WriterService>();
            container.RegisterType<IWriterRepository, EfWriterRepository>();

            container.RegisterType<IContactService, ContactService>();
            container.RegisterType<IContactRepository, EfContactRepository>();

            container.RegisterType<IMessageService, MessageService>();
            container.RegisterType<IMessageRepository, EfMessageRepository>();

            container.RegisterType<IImageFileService, ImageFileService>();
            container.RegisterType<IImageFileRepository, EfImageFileRepository>();

            container.RegisterType<IWriterLoginService, WriterLoginService>();
            container.RegisterType<IAdminLoginService, AdminLoginService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}