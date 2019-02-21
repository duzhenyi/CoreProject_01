using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
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
	public static class CoreConfig
	{
		private static IConfiguration config;
		public static IConfiguration Configuration
		{
			get
			{
				if (config != null) return config;
				var configBuilder = new ConfigurationBuilder().Add(new JsonConfigurationSource()
				{
					Path = "appsettings.json",
					ReloadOnChange = true
				});
				config = configBuilder.Build();
				return config;
			}
			set => config = value;
		}

		public static IConfigurationSection GetSection(string key)
		{
			return Configuration?.GetSection(key);
		}
		public static string GetConnectionString(string name)
		{
			return Configuration.GetConnectionString(name);
		}
		public static IEnumerable<IConfigurationSection> GetChildren()
		{
			return Configuration?.GetChildren();
		}
	}
}
