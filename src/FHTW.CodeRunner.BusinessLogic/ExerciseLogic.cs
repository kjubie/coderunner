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
        private readonly IUIRepository uiRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseLogic"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="exerciseRepository"></param>
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
            /* var dalExercise = this.exerciseRepository.GetById(1);
            var blExerciseShort = this.mapper.Map<BlEntities.ExerciseShort>(dalExercise);

            var list = new List<BlEntities.ExerciseShort>();
            list.Add(blExerciseShort); */

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
                if (exercise.Created == null)
                {
                    exercise.Created = DateTime.Now;
                }

                // if (exercise.ExerciseVersion != null)
                // {
                //     exercise.ExerciseVersion.FirstOrDefault().LastModified = DateTime.Now;
                //     exercise.ExerciseVersion.FirstOrDefault().ValidState = BlEntities.ValidState.NotChecked;
                // }

                var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);
                if (dalExercise.FkUser != null)
                {
                    dalExercise.FkUserId = dalExercise.FkUser.Id;
                }

                if (dalExercise.ExerciseVersion != null)
                {
                    if (dalExercise.ExerciseVersion.Count == 1)
                    {
                        var ver = dalExercise.ExerciseVersion.First();
                        ver.FkUserId = ver.FkUser.Id;

                        if (ver.ExerciseLanguage != null)
                        {
                            if (ver.ExerciseLanguage.Count == 1)
                            {
                                var lang = ver.ExerciseLanguage.First();
                                lang.FkWrittenLanguageId = lang.FkWrittenLanguage.Id;

                                if (lang.ExerciseBody != null)
                                {
                                    if (lang.ExerciseBody.Count == 1)
                                    {
                                        var body = lang.ExerciseBody.First();
                                        body.FkProgrammingLanguageId = body.FkProgrammingLanguage.Id;

                                        if (body.FkTestSuite != null)
                                        {
                                            body.FkTestSuite.FkQuestionTypeId = body.FkTestSuite.FkQuestionType.Id;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

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

                    if (exercise.ExerciseVersion != null)
                    {
                        exercise.ExerciseVersion.FirstOrDefault().LastModified = DateTime.Now;
                        exercise.ExerciseVersion.FirstOrDefault().ValidState = BlEntities.ValidState.Valid;
                    }

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
