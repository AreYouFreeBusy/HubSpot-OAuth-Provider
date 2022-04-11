//  Copyright 2021 Stefan Negritoiu (FreeBusy). See LICENSE file for more information.

using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;

namespace Owin.Security.Providers.HubSpot
{
    /// <summary>
    /// Provides context information to middleware providers.
    /// </summary>
    public class HubSpotReturnEndpointContext : ReturnEndpointContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">OWIN environment</param>
        /// <param name="ticket">The authentication ticket</param>
        public HubSpotReturnEndpointContext(
            IOwinContext context,
            AuthenticationTicket ticket)
            : base(context, ticket)
        {
        }
    }
}
