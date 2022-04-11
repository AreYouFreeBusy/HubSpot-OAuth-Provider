//  Copyright 2021 Stefan Negritoiu (FreeBusy). See LICENSE file for more information.

using System;
using System.Threading.Tasks;

namespace Owin.Security.Providers.HubSpot
{
    /// <summary>
    /// Default <see cref="IHubSpotAuthenticationProvider"/> implementation.
    /// </summary>
    public class HubSpotAuthenticationProvider : IHubSpotAuthenticationProvider
    {
        /// <summary>
        /// Initializes a <see cref="HubSpotAuthenticationProvider"/>
        /// </summary>
        public HubSpotAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null);
            OnReturnEndpoint = context => Task.FromResult<object>(null);
            OnBeforeRedirect = context => Task.FromResult<object>(null);
            OnApplyRedirect = context => context.Response.Redirect(context.RedirectUri);
        }

        /// <summary>
        /// Gets or sets the function that is invoked when the Authenticated method is invoked.
        /// </summary>
        public Func<HubSpotAuthenticatedContext, Task> OnAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the function that is invoked when the ReturnEndpoint method is invoked.
        /// </summary>
        public Func<HubSpotReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the delegate that is invoked when the BeforeRedirect method is invoked.
        /// </summary>
        public Action<HubSpotBeforeRedirectContext> OnBeforeRedirect { get; set; }

        /// <summary>
        /// Gets or sets the delegate that is invoked when the ApplyRedirect method is invoked.
        /// </summary>
        public Action<HubSpotApplyRedirectContext> OnApplyRedirect { get; set; }

        /// <summary>
        /// Invoked whenever HubSpot successfully authenticates a user
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task Authenticated(HubSpotAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        /// <summary>
        /// Invoked prior to the <see cref="System.Security.Claims.ClaimsIdentity"/> being saved in a local cookie and the browser being redirected to the originally requested URL.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task ReturnEndpoint(HubSpotReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }

        /// <summary>
        /// Called when a Challenge causes a redirect to authorize endpoint in the middleware, before the actual redirect.
        /// </summary>
        /// <param name="context">Contains redirect URI and <see cref="AuthenticationProperties"/> of the challenge </param>
        public virtual void BeforeRedirect(HubSpotBeforeRedirectContext context) 
        {
            OnBeforeRedirect(context);
        }

        /// <summary>
        /// Called when a Challenge causes a redirect to authorize endpoint in the HubSpot 2.0 middleware
        /// </summary>
        /// <param name="context">Contains redirect URI and <see cref="AuthenticationProperties"/> of the challenge </param>
        public virtual void ApplyRedirect(HubSpotApplyRedirectContext context) 
        {
            OnApplyRedirect(context);
        }
    }
}