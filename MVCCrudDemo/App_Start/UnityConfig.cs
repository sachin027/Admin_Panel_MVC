using MVCCrudDemo.Repository;
using MVCCrudDemo.Repository.Interface;
using MVCCrudDemo.Repository.Interface.LoginInterface;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MVCCrudDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
             container.RegisterType<IStudentInterface, StudentService>();
             container.RegisterType<IRegisterInterface, LoginService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}