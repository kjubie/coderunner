// <copyright file="UserApiController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
    /// <summary>
    /// All user operations can be accessed with this controller.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    public class UserApiController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IUserLogic userLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserApiController"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected AutoMapper.</param>
        /// <param name="userLogic">The injected logic class.</param>
        public UserApiController(ILogger<UserApiController> logger, IMapper mapper, IUserLogic userLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userLogic = userLogic;
        }

        /// <summary>
        /// Authenticating an user.
        /// </summary>
        /// <param name="body">User credentials.</param>
        /// <returns>A Statuscode.</returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("user/authenticate")]
        [SwaggerOperation("AuthenticateUser")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.AuthenticateOk), description: "Successfully authenticated the user")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult AuthenticateUser([FromBody] SvcEntities.UserAuthentication body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "User Authentication should not be null",
                });
            }

            var blUser = this.mapper.Map<BlEntities.User>(body);

            int? result = this.userLogic.AuthenticateUser(blUser);

            if (result.HasValue)
            {
                return this.Ok(new SvcEntities.AuthenticateOk
                {
                    Id = result.Value,
                });
            }
            else
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Username or password is incorrect",
                });
            }
        }
    }
}
