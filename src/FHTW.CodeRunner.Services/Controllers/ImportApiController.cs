// <copyright file="ImportApiController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
    /// <summary>
    /// All import operations can be accessed with this controller.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    public class ImportApiController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IImportLogic importLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportApiController"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected AutoMapper.</param>
        /// <param name="importLogic">The injected logic class.</param>
        public ImportApiController(ILogger<ImportApiController> logger, IMapper mapper, IImportLogic importLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.importLogic = importLogic;
        }

        /// <summary>
        /// Imports a collection.
        /// </summary>
        /// <returns>A Statuscode.</returns>
        [HttpPost]
        [Route("import/collection")]
        [SwaggerOperation("ImportCollection")]
        [SwaggerResponse(statusCode: 200, description: "Successfully imported the collection")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult ImportCollection()
        {
            return this.Ok();
        }
    }
}
