// <copyright file="ExerciseLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseLogic"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="exerciseRepository"></param>
        public ExerciseLogic(ILogger<ExerciseLogic> logger, IMapper mapper, IExerciseRepository exerciseRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
        }

        public BlEntities.ExerciseCreatePreparation GetExerciseCreatePreparation()
        {
            BlEntities.ExerciseCreatePreparation exerciseCreatePreparation = new BlEntities.ExerciseCreatePreparation();

            // TODO: Call dal functions
            exerciseCreatePreparation.ProgrammingLanguages = null;
            exerciseCreatePreparation.WrittenLanguages = null;
            exerciseCreatePreparation.QuestionTypes = null;

            return exerciseCreatePreparation;
        }

        /// <inheritdoc/>
        public BlEntities.Exercise GetTestExercise(int id)
        {
            var dalExercise = this.exerciseRepository.GetById(id);
            var blExercise = this.mapper.Map<BlEntities.Exercise>(dalExercise);

            return blExercise;
        }

        /// <inheritdoc/>
        public void SaveExercise(BlEntities.Exercise exercise)
        {
            if (exercise == null)
            {
                this.logger.LogError("Exercise is null");
                throw new BlValidationException("Exercise is null", null);
            }
            else
            {
                var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);
                this.exerciseRepository.Insert(dalExercise);
                this.logger.LogInformation("BL passing Exercise with Title: " + exercise.Title + " to DAL.");
            }
        }

        public void ValidateExercise(BlEntities.Exercise exercise)
        {
            if (exercise == null)
            {
                this.logger.LogError("Exercise is null");
                throw new BlValidationException("Exercise is null", null);
            }
            else
            {
                IValidator<BlEntities.Exercise> validator = new ExerciseValidator();
                var validationResult = validator.Validate(exercise);

                if (validationResult.IsValid)
                {
                    var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);
                    this.exerciseRepository.Insert(dalExercise);
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
}
