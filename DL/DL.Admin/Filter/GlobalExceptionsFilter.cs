using Castle.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.Admin.Filter
{
	public class GlobalExceptionsFilter : IExceptionFilter
	{
		private readonly IHostingEnvironment _env;
		private readonly ILogger _logger;

		public GlobalExceptionsFilter(IHostingEnvironment env, ILogger logger)
		{
			_env = env;
			_logger = logger;
		}
		public void OnException(ExceptionContext context)
		{
			string message = context.Exception.Message;//错误信息
			if (_env.IsDevelopment())
			{
				message = context.Exception.StackTrace;//堆栈信息
			}
			context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult(message)
			{
				//Value = message,
				StatusCode = StatusCodes.Status500InternalServerError
			};

			//采用log4net 进行错误日志记录
			_logger.Error(string.Format("【自定义错误】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}",
					message,
					context.GetType().Name,
					context.Exception.Message,
					context.Exception.StackTrace));
		}

	}
}
