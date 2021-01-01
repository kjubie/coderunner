// <copyright file="ExportApiController.cs" company="FHTW CodeRunner">
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
        public virtual IActionResult ExportExercise([FromBody] SvcEntities.ExportExercise body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Exercise should not be null",
                });
            }

            var blExportExercise = this.mapper.Map<BlEntities.ExportExercise>(body);

            string xmlString = this.exportLogic.ExportExercise(blExportExercise);

            return new ContentResult
            {
                ContentType = "application/xml",
                Content = xmlString,
                StatusCode = 200,
            };
        }

        /// <summary>
        /// Exports a collection.
        /// </summary>
        /// <param name="body">Defining collection parameters.</param>
        /// <returns>A Moodle XML Document.</returns>
        [HttpPost]
        [Route("export/collection")]
        public virtual IActionResult ExportCollection([FromBody] SvcEntities.Collection body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Collection should not be null",
                });
            }

            var blCollection = this.mapper.Map<BlEntities.Collection>(body);

            this.exportLogic.ExportCollection(blCollection);
            return this.Ok();
        }
    }
}
