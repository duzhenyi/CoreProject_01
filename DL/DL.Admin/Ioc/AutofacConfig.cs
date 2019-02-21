using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DL.IServices;


namespace DL.Admin.Ioc
{
    /// <summary>
    /// 在Nuget中引入两个：
    /// Autofac.Extras.DynamicProxy（Autofac的动态代理，它依赖Autofac，所以可以不用单独引入Autofac）、
    /// Autofac.Extensions.DependencyInjection（Autofac的扩展）
    /// </summary>
    public class AutofacConfig
    {
        public static IContainer autofacContainer { get; private set; }
        /// <summary>
        /// 负责调用autofac实现依赖注入，负责创建MVC控制器类的对象(调用控制器的有参构造函数)，接管DefaultControllerFactory的工作
        /// </summary>
        public static AutofacServiceProvider RegisterMVC(IServiceCollection services)
        {
            //实例化 Autofac 容器
            ContainerBuilder builder = new ContainerBuilder();

            //组件注册
            builder.RegisterModule<DefaultModuleRegister>();

            //将services中的服务填充到Autofac 容器生成器
            builder.Populate(services);

            //使用已进行的组件登记创建新容器
            autofacContainer = builder.Build();

            return new AutofacServiceProvider(autofacContainer);//第三方IOC接管 core内置DI容器

        }
    }
}
