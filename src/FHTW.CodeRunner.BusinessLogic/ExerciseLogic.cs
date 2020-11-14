// <copyright file="ExerciseLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.BusinessLogic.Validators;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    public class ExerciseLogic : IExerciseLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExerciseRepository exerciseRepository;

        public ExerciseLogic(ILogger<IExerciseLogic> logger, IMapper mapper, IExerciseRepository exerciseRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
        }

        /// <inheritdoc/>
        public BlEntities.Exercise GetTestExercise(int id)
        {
            var dalExercise = this.exerciseRepository.GetExerciseById(id);
            var blExercise = this.mapper.Map<BlEntities.Exercise>(dalExercise);

            return blExercise;
        }

        /// <inheritdoc/>
        public void SaveExercise(BlEntities.Exercise exercise)
        {
            IValidator<BlEntities.Exercise> validator = new ExerciseValidator();
            var validationResult = validator.Validate(exercise);

            if (validationResult.IsValid)
            {
                var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);
                // this.exerciseRepository.SaveExercise(dalExercise);
                this.logger.LogInformation("BL passing Exercise with Title: " + exercise.Title + " to DAL.");
            }
            else
            {
                this.logger.LogError("BL received invalid Exercise in SaveExercise with Title: " + exercise.Title);
                throw new ValidationException("exercise " + validationResult.Errors.Select(err => err.ErrorMessage).ToString());
            }
        }
    }
}
