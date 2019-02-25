using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using DL.Admin.Filter;
using DL.Admin.Ioc;
using DL.Common.Config;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DL.Admin
{
	public class Startup
	{
		public static ILoggerRepository repository { get; set; }

		public Startup(IConfiguration configuration)
		{
			CoreConfig.Configuration = Configuration = configuration;
			//log4net
			repository = LogManager.CreateRepository("DL.Admin");
			XmlConfigurator.Configure(repository, new FileInfo("log4net.config")); //指定配置文件
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});
			services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));//解决视图输出内容中文编码问题
			services.AddMvc(option =>
			{
				//option.Filters.Add(typeof(GlobalExceptionsFilter));//注入全局异常捕获
			}).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			/* Core 自带方式注入
             services.AddScoped<IEmailService, EmailService>();
			 services.AddTransient<IEmailService, EmailService>();
           */

			//var config = builder.Build();
			//services.Configure<SiteConfig>(config.GetSection("SiteConfig"));
			//services.Configure<VisitDistrictRequest>(config.GetSection("VisitDistrictRequest"));

			return AutofacConfig.RegisterMVC(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();//启动异常捕获
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");//启动异常处理方法
			}

			app.UseStaticFiles();//启动静态文件
			//app.UseAuthentication();//启动身份验证
			app.UseCookiePolicy();//启动cookie策略
			//app.UseHttpsRedirection();//启动HTTP 请求重定向到 HTTPS
			//app.UseSession();//启动配置会话
			//app.UseForwardedHeaders(new ForwardedHeadersOptions()
			//{//https://www.cnblogs.com/huaxingtianxia/p/6369089.html
			//	ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor |
			//					   Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
			//});
			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=AdminLogin}/{id?}");
				routes.MapRoute(
					name: "areas",
					template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
