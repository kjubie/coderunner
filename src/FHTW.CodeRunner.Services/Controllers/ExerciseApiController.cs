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
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
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
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="exerciseLogic"></param>
        public ExerciseApiController(ILogger<ExerciseApiController> logger, IMapper mapper, IExerciseLogic exerciseLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseLogic = exerciseLogic;
        }

        [HttpGet]
        [Route("exercise/{id}")]
        public virtual IActionResult GetTestExercise(int id)
        {
            BlEntities.Exercise blExercise = this.exerciseLogic.GetTestExercise(id);
            var svcExercise = this.mapper.Map<SvcEntities.Exercise>(blExercise);

            return this.Ok(svcExercise);
        }

        [HttpPost]
        [Route("exercise")]
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

        [HttpPost]
        [Route("exercise/validate")]
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

        [HttpGet]
        [Route("exercise/prepare")]
        public virtual IActionResult GetExerciseCreatePreparation()
        {
            BlEntities.ExerciseCreatePreparation blExerciseCreatePreparation = this.exerciseLogic.GetExerciseCreatePreparation();
            var svcExerciseCreatePreparation = this.mapper.Map<SvcEntities.ExerciseCreatePreparation>(blExerciseCreatePreparation);

            return this.Ok(svcExerciseCreatePreparation);
        }

        [HttpGet]
        [Route("exercise/short")]
        public virtual IActionResult GetExerciseShort()
        {
            List<BlEntities.ExerciseShort> blExerciseShort = this.exerciseLogic.GetExerciseShortList();
            var svcExerciseShort = this.mapper.Map<List<SvcEntities.ExerciseShort>>(blExerciseShort);

            return this.Ok(svcExerciseShort);
        }
    }
}
