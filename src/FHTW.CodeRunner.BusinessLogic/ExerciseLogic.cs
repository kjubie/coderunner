// <copyright file="ExerciseLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
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
    /// <summary>
    /// Logic Class for dealing with exercise actions.
    /// </summary>
    public class ExerciseLogic : IExerciseLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExerciseRepository exerciseRepository;
        private readonly IUIRepository uiRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseLogic"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected mapper.</param>
        /// <param name="exerciseRepository">The injected exercise repository.</param>
        /// <param name="uiRepository">The injected ui repository.</param>
        public ExerciseLogic(ILogger<ExerciseLogic> logger, IMapper mapper, IExerciseRepository exerciseRepository, IUIRepository uiRepository)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
            this.uiRepository = uiRepository;
        }

        /// <inheritdoc/>
        public List<BlEntities.ExerciseShort> GetExerciseShortList()
        {
            // TODO: Rename
            var dalExerciseList = this.exerciseRepository.GetMinimalList();
            var blExerciseList = this.mapper.Map<List<BlEntities.ExerciseShort>>(dalExerciseList);

            return blExerciseList;
        }

        /// <inheritdoc/>
        public BlEntities.ExerciseCreatePreparation GetExerciseCreatePreparation()
        {
            BlEntities.ExerciseCreatePreparation exerciseCreatePreparation = new BlEntities.ExerciseCreatePreparation();

            var dalProgrammingLanguages = this.uiRepository.GetProgrammingLanguages();
            exerciseCreatePreparation.ProgrammingLanguages = this.mapper.Map<List<BlEntities.ProgrammingLanguage>>(dalProgrammingLanguages);

            var dalWrittenLanguages = this.uiRepository.GetWrittenLanguages();
            exerciseCreatePreparation.WrittenLanguages = this.mapper.Map<List<BlEntities.WrittenLanguage>>(dalWrittenLanguages);

            var dalQuestionTypes = this.uiRepository.GetQuestionTypes();
            exerciseCreatePreparation.QuestionTypes = this.mapper.Map<List<BlEntities.QuestionType>>(dalQuestionTypes);

            var dalTags = this.uiRepository.GetTags();
            exerciseCreatePreparation.Tags = this.mapper.Map<List<BlEntities.Tag>>(dalTags);

            return exerciseCreatePreparation;
        }

        /// <inheritdoc/>
        public BlEntities.Exercise GetExerciseById(int id, int version)
        {
            var dalExercise = this.exerciseRepository.GetById(id, version);
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
                if (exercise.Created == null)
                {
                    exercise.Created = DateTime.Now;
                }

                var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);

                this.exerciseRepository.CreateAndUpdate(dalExercise);
                this.logger.LogInformation("BL passing Exercise with Title: " + exercise.Title + " to DAL.");
            }
        }

        /// <inheritdoc/>
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
                    if (exercise.Created == null)
                    {
                        exercise.Created = DateTime.Now;
                    }

                    /*if (exercise.ExerciseVersion != null)
                    {
                        exercise.ExerciseVersion.FirstOrDefault().LastModified = DateTime.Now;
                        exercise.ExerciseVersion.FirstOrDefault().ValidState = BlEntities.ValidState.Valid;
                    }*/

                    var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);
                    this.exerciseRepository.CreateAndUpdate(dalExercise);
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
