// <copyright file="BasicAuthenticationHandler.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.Services.Helpers
{
    /// <summary>
    /// Class for handling the basic authentication.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserLogic userLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicAuthenticationHandler"/> class.
        /// </summary>
        /// <param name="options">The injected authenication options.</param>
        /// <param name="logger">The injected logger.</param>
        /// <param name="encoder">The injected url encoder.</param>
        /// <param name="clock">The injected system clock.</param>
        /// <param name="userLogic">The injected logic class.</param>
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserLogic userLogic)
            : base(options, logger, encoder, clock)
        {
            this.userLogic = userLogic;
        }

        /// <inheritdoc/>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // skip authentication if endpoint has [AllowAnonymous] attribute
            var endpoint = this.Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!this.Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail(Request);
            }

            int? result = null;
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(this.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                var username = credentials[0];
                var password = credentials[1];
                BlEntities.User user = new BlEntities.User
                {
                    Name = username,
                    Password = password,
                };
                result = this.userLogic.AuthenticateUser(user); // TODO: Make Async
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (!result.HasValue)
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "testId"), // TODO: Research Claim
                new Claim(ClaimTypes.Name, "root"), // TODO: Research Claim
            };
            var identity = new ClaimsIdentity(claims, this.Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, this.Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
