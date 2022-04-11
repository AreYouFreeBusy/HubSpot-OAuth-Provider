//  Copyright 2021 Stefan Negritoiu (FreeBusy). See LICENSE file for more information.

using System;

namespace Owin.Security.Providers.HubSpot
{
    public static class HubSpotAuthenticationExtensions
    {
        public static IAppBuilder UseHubSpotAuthentication(this IAppBuilder app, HubSpotAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException("app");
            if (options == null)
                throw new ArgumentNullException("options");

            app.Use(typeof(HubSpotAuthenticationMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UseHubSpotAuthentication(this IAppBuilder app, string clientId, string clientSecret)
        {
            return app.UseHubSpotAuthentication(new HubSpotAuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });
        }
    }
}