// <copyright file="ExerciseApiController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
    [ApiController]
    [Route("api")]
    public class ExerciseApiController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExerciseLogic exerciseLogic;

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
                // TODO: Error Model
                return this.BadRequest("Exercise should not be null");
            }

            var blExercise = this.mapper.Map<BlEntities.Exercise>(body);

            this.exerciseLogic.SaveExercise(blExercise);
            return this.Ok();
        }
    }
}
