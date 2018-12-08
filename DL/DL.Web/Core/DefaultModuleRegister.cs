using Autofac;
using DL.IService;
using DL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace DL.Web.Core
{
    public class DefaultModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //1. 单个注册
            //builder.RegisterType(typeof(IEmailService)).As(typeof(EmailService));//EmailService IEmailService 

            //2. 批量注册 注册当前程序集中以“Service”结尾的类,暴漏类实现的所有接口
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()//表示注册的类型，以接口的方式注册
                .InstancePerLifetimeScope();//即为每一个依赖或调用创建一个单一的共享的实例

            //3. 集体注册 注册所有"DL.Repository"程序集中的类
            //builder.RegisterAssemblyTypes(GetAssembly("DL")).AsImplementedInterfaces();
        }
    }
}
 
 
