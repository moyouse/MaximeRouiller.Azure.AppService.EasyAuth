using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;

namespace DemoFunctionApp
{
    public static class Function1
    {

        [Authorize(AuthenticationSchemes = "EasyAuth")]
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                var accessor = new HttpContextAccessor();

                var list = accessor.HttpContext.User.Claims.Select(c => c.Value).ToArray();

                var result =
                 JsonConvert.SerializeObject(accessor.HttpContext.User.Claims, new JsonSerializerSettings()
                 {
                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                 });

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {

                return new OkObjectResult(ex.Message);
            }


        }

    }
}
