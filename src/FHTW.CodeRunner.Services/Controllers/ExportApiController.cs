// <copyright file="ExportApiController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
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
    /// All export operations can be accessed with this controller.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    public class ExportApiController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExportLogic exportLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportApiController"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected AutoMapper.</param>
        /// <param name="exportLogic">The injected logic class.</param>
        public ExportApiController(ILogger<ExportApiController> logger, IMapper mapper, IExportLogic exportLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exportLogic = exportLogic;
        }

        /// <summary>
        /// Exports a single exercise.
        /// </summary>
        /// <param name="body">Defining exercise parameters.</param>
        /// <returns>A Moodle XML Document.</returns>
        [HttpPost]
        [Route("export/exercise")]
        [SwaggerOperation("ExportExercise")]
        [SwaggerResponse(statusCode: 200, description: "Successfully exported the exercise")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult ExportExercise([FromBody] SvcEntities.ExerciseKeys body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Exercise should not be null",
                });
            }

            try
            {
                var blExerciseKeys = this.mapper.Map<BlEntities.ExerciseKeys>(body);

                string xmlString = this.exportLogic.ExportExercise(blExerciseKeys);

                return new ContentResult
                {
                    ContentType = "application/xml",
                    Content = xmlString,
                    StatusCode = 200,
                };
            }
            catch (BlValidationException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
            catch (BlDataAccessException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
        }

        /// <summary>
        /// Exports a collection.
        /// </summary>
        /// <param name="body">Defining collection parameters.</param>
        /// <returns>A Moodle XML Document.</returns>
        [HttpPost]
        [Route("export/collection")]
        [SwaggerOperation("ExportCollection")]
        [SwaggerResponse(statusCode: 200, description: "Successfully exported the collection")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult ExportCollection([FromBody] SvcEntities.CollectionKeys body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Collection should not be null",
                });
            }

            try
            {
                var blCollectionKeys = this.mapper.Map<BlEntities.CollectionKeys>(body);

                string xmlString = this.exportLogic.ExportCollection(blCollectionKeys);

                return new ContentResult
                {
                    ContentType = "application/xml",
                    Content = xmlString,
                    StatusCode = 200,
                };
            }
            catch (BlValidationException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
            catch (BlDataAccessException e)
            {
                this.logger.LogError(e.Message);
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = e.Message,
                });
            }
        }
    }
}
