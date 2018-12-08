using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DL.Web.Core
{
    public class AutofacConfig
    {
        public static IContainer AutofacContainer { get; private set; }
        /// <summary>
        /// 负责调用autofac实现依赖注入，负责创建MVC控制器类的对象(调用控制器的有参构造函数)，接管DefaultControllerFactory的工作
        /// </summary>
        public static AutofacServiceProvider RegisterMVC(IServiceCollection services)
        {
            
            ContainerBuilder builder = new ContainerBuilder();//实例化autofac的创建容器
            builder.Populate(services);//将services中的服务填充到Autofac中.
            AutofacContainer = builder.Build();//创建容器.

            //builder.RegisterModule<DefaultModuleRegister>(); //新模块组件注册

            return   new AutofacServiceProvider(AutofacContainer);//第三方IOC接管 core内置DI容器

        }
    }
}
