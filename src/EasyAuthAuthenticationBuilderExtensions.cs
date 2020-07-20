using Microsoft.AspNetCore.Authentication;
using System;

namespace MaximeRouiller.Azure.AppService.EasyAuth
{
    public static class EasyAuthAuthenticationBuilderExtensions
    {
        public static AuthenticationBuilder AddEasyAuthAuthentication(
            this AuthenticationBuilder builder,
          Action<EasyAuthAuthenticationOptions> configure) =>
                builder.AddScheme<EasyAuthAuthenticationOptions, EasyAuthAuthenticationHandler>(
                    "EasyAuth",
                    "EasyAuth",
                    configure)
        .AddScheme<EasyAuthAuthenticationOptions, EasyAuthAuthenticationHandler>(
                    "ArmToken",
                    "ArmToken",
                    configure)

 


        .AddScheme<EasyAuthAuthenticationOptions, EasyAuthAuthenticationHandler>(
                    "WebJobsAuthLevel",
                    "WebJobsAuthLevel",
                    configure)
        .AddScheme<EasyAuthAuthenticationOptions, EasyAuthAuthenticationHandler>(
                    "Bearer",
                    "Bearer",
                    configure);
    }
}
