//  Copyright 2017 Stefan Negritoiu. See LICENSE file for more information.

using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.Provider;

namespace Owin.Security.Providers.HubSpot
{
    /// <summary>
    /// Context passed when a Challenge causes a redirect to authorize endpoint in the HubSpot OAuth 2.0 middleware
    /// </summary>
    public class HubSpotBeforeRedirectContext : BaseContext<HubSpotAuthenticationOptions>
    {
        /// <summary>
        /// Creates a new context object.
        /// </summary>
        /// <param name="context">The OWIN request context</param>
        /// <param name="options">The HubSpot middleware options</param>
        public HubSpotBeforeRedirectContext(IOwinContext context, HubSpotAuthenticationOptions options)
            : base(context, options) 
        {
        }
    }
}
