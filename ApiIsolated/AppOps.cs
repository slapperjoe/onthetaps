using System.Collections.Generic;
using System.Net;
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
				string[] files = Directory.GetFiles(".", "*.*", SearchOption.AllDirectories);
				response.WriteString(String.Join(",", files));
			} catch (Exception ex)
			{
				response.StatusCode = HttpStatusCode.InternalServerError;
				response.WriteString(ex.Message);
			}
			
			return response;
		}
	}
}
