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
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
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
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="userLogic"></param>
        public UserApiController(ILogger<UserApiController> logger, IMapper mapper, IUserLogic userLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.userLogic = userLogic;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("user/authenticate")]
        public virtual IActionResult AuthenticateUser([FromBody] SvcEntities.UserAuthentication body)
        {
            if (body == null)
            {
                // TODO: Error Model
                return this.BadRequest("Exercise should not be null");
            }

            bool result = this.userLogic.AuthenticateUser(body.Name, body.Password);

            if (result)
            {
                return this.Ok();
            }
            else
            {
                return this.BadRequest(new { message = "Username or password is incorrect" });
            }
        }
    }
}
