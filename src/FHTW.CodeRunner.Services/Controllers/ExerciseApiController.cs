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
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Controllers
{
    [ApiController]
    public class ExerciseApiController : ControllerBase
    {
        private readonly IMapper mapper = AutoMapper.MapperProfile.InitializeAutoMapper().CreateMapper();
        private readonly IExerciseLogic exerciseLogic;

        public ExerciseApiController(IMapper mapper, IExerciseLogic exerciseLogic)
        {
            this.mapper = mapper;
            this.exerciseLogic = exerciseLogic;
        }

        [HttpGet]
        [Route("api/exercise/{id}")]
        public virtual IActionResult GetTestExercise(int id)
        {
            BlEntities.Exercise blExercise = this.exerciseLogic.GetTestExercise(id);
            var svcExercise = this.mapper.Map<SvcEntities.Exercise>(blExercise);

            return this.Ok(svcExercise);
        }
    }
}
