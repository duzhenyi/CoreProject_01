using Autofac;
using Autofac.Extras.DynamicProxy;
using DL.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace DL.Admin.Ioc
{
    public class DefaultModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //1. 单个注册,注册通过反射来创建的组件
            //builder.RegisterType<SysManagerService>().As<ISysManagerService>();

            //2. 批量注册 注册当前程序集中以“Service”结尾的类,暴漏类实现的所有接口
            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces()//表示注册的类型，以接口的方式注册
            //    .InstancePerLifetimeScope();//即为每一个依赖或调用创建一个单一的共享的实例

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

			var repositoryDllFile = Path.Combine(basePath, "DL.Repository.MySql.dll");//获取项目绝对路径
						builder.RegisterAssemblyTypes(Assembly.LoadFile(repositoryDllFile))//直接采用加载文件的方法
							   .AsImplementedInterfaces()//表示注册的类型，以接口的方式注册
							   .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy
							   .InstancePerLifetimeScope();//即为每一个依赖或调用创建一个单一的共享的实例

			var servicesDllFile = Path.Combine(basePath, "DL.Services.dll");
			builder.RegisterAssemblyTypes(Assembly.LoadFile(servicesDllFile))
				   .AsImplementedInterfaces()
				   .EnableInterfaceInterceptors()
				   .InstancePerLifetimeScope();
  
			

		}
    }
}
 
 
