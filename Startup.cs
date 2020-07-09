using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using MaximeRouiller.Azure.AppService.EasyAuth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;
using System.Linq;
using Newtonsoft.Json;

[assembly: FunctionsStartup(typeof(FunctionApp26.Startup))]

namespace FunctionApp26
{
   

    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
         

            builder.Services.AddAuthentication().AddEasyAuthAuthentication((o) => {
         
            });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            builder.Services.AddHttpContextAccessor();

        }
    }


}
