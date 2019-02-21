using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using DL.CodeGenerator.Models;
using DL.CodeGenerator.Options;
using DL.CodeGenerator.Core;

namespace DL.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = BuildServiceForSqlServer();
                var codeGenerator = serviceProvider.GetRequiredService<MainGenerator>();
                codeGenerator.GenerateCodesFromDatabase(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 构造依赖注入容器，然后传入参数
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider BuildServiceForSqlServer()
        {
            var services = new ServiceCollection();

            services.Configure<DefineOption>(options =>
            {
                options.ConnectionString = "Data Source=.;Initial Catalog=DLDB;User ID=sa;Password=123456;Persist Security Info=True;Max Pool Size=50;Min Pool Size=0;Connection Lifetime=300;";
                options.DBType = DBType.SqlServer.ToString();
                options.Author = "duling";
                options.OutputPath = AppContext.BaseDirectory + "\\Code";//模板代码生成的路径
                options.ModelsNamespace = "DL.Models";//实体命名空间
                options.IRepositoryNamespace = "DL.IRepository";//仓储接口命名空间
                options.RepositoryNamespace = "DL.Repository.SqlServer";//仓储命名空间
                options.IServiceNamespace = "DL.IServices";
                options.ServiceNamespace = "DL.Services";
            });
            services.AddSingleton<MainGenerator>();//注入Model代码生成器
            services.Configure<DBOption>("DL", GetConfiguration().GetSection("DBOption"));
            return services.BuildServiceProvider(); //构建服务提供程序
        }

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
