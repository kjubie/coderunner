// <copyright file="ExerciseApiController.cs" company="FHTW CodeRunner">
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
        /// Gets a test exercise.
        /// </summary>
        /// <param name="id">The Id of the test exercise.</param>
        /// <returns>One exercise.</returns>
        [HttpGet]
        [Route("exercise/{id}")]
        [SwaggerOperation("GetTestExercise")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.Exercise), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetTestExercise(int id)
        {
            BlEntities.Exercise blExercise = this.exerciseLogic.GetTestExercise(id);
            var svcExercise = this.mapper.Map<SvcEntities.Exercise>(blExercise);

            return this.Ok(svcExercise);
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

            var blExercise = this.mapper.Map<BlEntities.Exercise>(body);

            this.exerciseLogic.SaveExercise(blExercise);
            return this.Ok();
        }

        /// <summary>
        /// Validates an exercise.
        /// </summary>
        /// <param name="body">An exercise.</param>
        /// <returns>A Statuscode.</returns>
        [HttpPost]
        [Route("exercise/validate")]
        [SwaggerOperation("ValidateExercise")]
        [SwaggerResponse(statusCode: 200, description: "Successfully validated")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "The operation failed due to an error.")]
        public virtual IActionResult ValidateExercise([FromBody] SvcEntities.Exercise body)
        {
            if (body == null)
            {
                return this.BadRequest(new SvcEntities.Error
                {
                    ErrorMessage = "Exercise should not be null",
                });
            }

            var blExercise = this.mapper.Map<BlEntities.Exercise>(body);

            this.exerciseLogic.ValidateExercise(blExercise);
            return this.Ok();
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
            BlEntities.ExerciseCreatePreparation blExerciseCreatePreparation = this.exerciseLogic.GetExerciseCreatePreparation();
            var svcExerciseCreatePreparation = this.mapper.Map<SvcEntities.ExerciseCreatePreparation>(blExerciseCreatePreparation);

            return this.Ok(svcExerciseCreatePreparation);
        }

        /// <summary>
        /// Gets a list of exercises.
        /// </summary>
        /// <returns>A list of exercises in a minmal format.</returns>
        [HttpGet]
        [Route("exercise/short")]
        [SwaggerOperation("GetExerciseShort")]
        [SwaggerResponse(statusCode: 200, type: typeof(SvcEntities.ExerciseShort), description: "Successful response")]
        [SwaggerResponse(statusCode: 400, type: typeof(SvcEntities.Error), description: "An error occurred loading.")]
        public virtual IActionResult GetExerciseShort()
        {
            List<BlEntities.ExerciseShort> blExerciseShort = this.exerciseLogic.GetExerciseShortList();
            var svcExerciseShort = this.mapper.Map<List<SvcEntities.ExerciseShort>>(blExerciseShort);

            return this.Ok(svcExerciseShort);
        }
    }
}
