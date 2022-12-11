using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ApiIsolated
{
	public class AppOps
	{
		private readonly ILogger _logger;

		public AppOps(ILoggerFactory loggerFactory)
		{
			_logger = loggerFactory.CreateLogger<AppOps>();
		}

		[Function("LatestVersion")]
		public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
		{
			_logger.LogInformation("C# HTTP trigger function processed a request.");
			var response = req.CreateResponse(HttpStatusCode.OK);
			response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
			try
			{
				var dir = new DirectoryInfo("dl");
				var updateFile = dir.GetFiles().ToList().OrderByDescending(a => a.CreationTime).FirstOrDefault();
				var version = AssemblyName.GetAssemblyName(updateFile.FullName).Version;
				response.WriteString("");
			} catch (Exception ex)
			{
				response.StatusCode = HttpStatusCode.InternalServerError;
				response.WriteString(ex.Message);
			}
			
			return response;
		}
	}
}
