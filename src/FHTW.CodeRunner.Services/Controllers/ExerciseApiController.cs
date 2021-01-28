// <copyright file="ExerciseApiController.cs" company="FHTW CodeRunner">
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
using Swashbuckle.AspNetCore.SwaggerGen;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
    /// <summary>
    /// All exercise operations can be accessed with this controller.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api")]
    public class ExerciseApiController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExerciseLogic exerciseLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseApiController"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected AutoMapper.</param>
        /// <param name="exerciseLogic">The injected logic class.</param>
        public ExerciseApiController(ILogger<ExerciseApiController> logger, IMapper mapper, IExerciseLogic exerciseLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseLogic = exerciseLogic;
        }

        /// <summary>
        /// Gets an exercise by id.
        /// </summary>
        /// <param name="id">The Id of the exercise.</param>
        /// <returns>One exercise.</returns>
        [HttpGet]
        [Route("exercise/{id}")]
        [SwaggerOperation("GetExerciseById")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.Exercise), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetExerciseById(int id)
        {
            try
            {
                int version = -1;
                BlEntities.Exercise blExercise = this.exerciseLogic.GetExerciseById(id, version);
                var svcExercise = this.mapper.Map<SvcEntities.Exercise>(blExercise);

                return this.Ok(svcExercise);
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
        /// Gets an exercise by id and version.
        /// </summary>
        /// <param name="id">The Id of the exercise.</param>
        /// <param name="version">The version of the exercise.</param>
        /// <returns>One exercise.</returns>
        [HttpGet]
        [Route("exercise/{id}/{version}")]
        [SwaggerOperation("GetExerciseById")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.Exercise), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetExerciseById(int id, int version)
        {
            try
            {
                BlEntities.Exercise blExercise = this.exerciseLogic.GetExerciseById(id, version);
                var svcExercise = this.mapper.Map<SvcEntities.Exercise>(blExercise);

                return this.Ok(svcExercise);
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
        /// Saves an exercise to the system.
        /// </summary>
        /// <param name="body">An exercise.</param>
        /// <returns>A Statuscode.</returns>
        [HttpPost]
        [Route("exercise")]
        [SwaggerOperation("SaveExercise")]
        [SwaggerResponse(statusCode: 200, description: "Successfully saved the exercise")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult SaveExercise([FromBody] SvcEntities.Exercise body)
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
                var blExercise = this.mapper.Map<BlEntities.Exercise>(body);

                this.exerciseLogic.SaveExercise(blExercise);
                return this.Ok();
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
        /// Saves an exercise to the system temporarily.
        /// </summary>
        /// <param name="body">An exercise.</param>
        /// <returns>A Statuscode.</returns>
        [HttpPost]
        [Route("exercise/temporary")]
        [SwaggerOperation("TemporarySaveExercise")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.Exercise), description: "Successfully saved the exercise temporarily")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult TemporarySaveExercise([FromBody] SvcEntities.Exercise body)
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
                var blExercise = this.mapper.Map<BlEntities.Exercise>(body);

                var blNewExercise = this.exerciseLogic.TemporarySaveExercise(blExercise);
                var svcNexExercise = this.mapper.Map<SvcEntities.Exercise>(blNewExercise);

                return this.Ok(svcNexExercise);
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
        /// Validates an exercise.
        /// </summary>
        /// <param name="id">The id of the exercise.</param>
        /// <param name="version">The version of the exercise.</param>
        /// <param name="body">An exercise.</param>
        /// <returns>A Statuscode.</returns>
        [HttpPost]
        [Route("exercise/validate/{id}/{version}")]
        [SwaggerOperation("ValidateExercise")]
        [SwaggerResponse(statusCode: 200, description: "Successfully validated")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult ValidateExercise(int id, int version, [FromBody] SvcEntities.Exercise body)
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
                var blExercise = this.mapper.Map<BlEntities.Exercise>(body);

                this.exerciseLogic.ValidateExercise(blExercise, id, version);
                return this.Ok();
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
        /// Gets data for the 'Create Exercise'-section in the frontend.
        /// </summary>
        /// <returns>Lists of necessary attributes.</returns>
        [HttpGet]
        [Route("exercise/prepare")]
        [SwaggerOperation("GetExerciseCreatePreparation")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.ExerciseCreatePreparation), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetExerciseCreatePreparation()
        {
            try
            {
                BlEntities.ExerciseCreatePreparation blExerciseCreatePreparation = this.exerciseLogic.GetExerciseCreatePreparation();
                var svcExerciseCreatePreparation = this.mapper.Map<SvcEntities.ExerciseCreatePreparation>(blExerciseCreatePreparation);

                return this.Ok(svcExerciseCreatePreparation);
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
        /// Gets a list of exercises.
        /// </summary>
        /// <returns>A list of exercises in a minmal format.</returns>
        [HttpGet]
        [Route("exercise/minimal")]
        [SwaggerOperation("GetMinimalExercise")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SvcEntities.MinimalExercise>), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetMinimalExercise()
        {
            try
            {
                List<BlEntities.MinimalExercise> blExerciseShort = this.exerciseLogic.GetMinimalExerciseList();
                var svcExerciseShort = this.mapper.Map<List<SvcEntities.MinimalExercise>>(blExerciseShort);

                return this.Ok(svcExerciseShort);
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
        /// Searches and filters for a list of exercises.
        /// </summary>
        /// <param name="body">Options for filtering.</param>
        /// <returns>A list of exercises in a minmal format.</returns>
        [HttpPost]
        [Route("exercise/search")]
        [SwaggerOperation("SearchAndFilterExercises")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<SvcEntities.MinimalExercise>), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult SearchAndFilterExercises([FromBody] SvcEntities.SearchExercise body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Search for Exercise should not be null",
                });
            }

            try
            {
                var blSearchObject = this.mapper.Map<BlEntities.SearchObject>(body);
                List<BlEntities.MinimalExercise> blMinimalExerciseList = this.exerciseLogic.SearchAndFilter(blSearchObject);
                var svcMinimalExerciseList = this.mapper.Map<List<SvcEntities.MinimalExercise>>(blMinimalExerciseList);

                return this.Ok(svcMinimalExerciseList);
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
