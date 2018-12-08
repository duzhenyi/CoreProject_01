using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DL.Common.Config
{
    /// <summary>
    /// .net core的配置导入
    /// </summary>
    internal class CoreConfig
    {
        ///// <summary>
        ///// 配置对象
        ///// </summary>
        internal static IConfiguration Configuration =>
            new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", true, true)
            .AddInMemoryCollection().AddEnvironmentVariables().Build();
            //.AddApplicationInsightsSettings().Build(); 
    }
}
