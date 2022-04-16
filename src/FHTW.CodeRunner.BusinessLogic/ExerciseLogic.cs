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
        public List<BlEntities.MinimalExercise> GetMinimalExerciseList()
        {
            try
            {
                var dalExerciseList = this.exerciseRepository.GetMinimalList();
                var blExerciseList = this.mapper.Map<List<BlEntities.MinimalExercise>>(dalExerciseList);

                return blExerciseList;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("Unable to retrieve a list of minimal exercises from the DAL!", e);
            }
        }

        /// <inheritdoc/>
        public BlEntities.ExerciseCreatePreparation GetExerciseCreatePreparation()
        {
            try
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
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("Unable to retrieve data for the creation of an exercise from the DAL!", e);
            }
        }

        /// <inheritdoc/>
        public BlEntities.Exercise GetExerciseById(int id, int version)
        {
            try
            {
                // TODO: Data not found Exception.
                var dalExercise = this.exerciseRepository.GetById(id, version);
                var blExercise = this.mapper.Map<BlEntities.Exercise>(dalExercise);

                return blExercise;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("Unable to retrieve an exercis by from the DAL!", e);
            }
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
                try
                {
                    if (exercise.Created == null || (exercise.ExerciseVersion?.First()?.VersionNumber ?? 0) < 1)
                    {
                        exercise.Created = DateTime.Now;
                    }

                    var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);

                    this.exerciseRepository.Save(dalExercise);
                    this.logger.LogInformation("BL passing Exercise with Title: " + exercise.Title + " to DAL.");
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    throw new BlDataAccessException("Unable to save Exercise with Title: " + exercise.Title + " to DAL." + e, e);
                }
            }
        }

        /// <inheritdoc/>
        public BlEntities.Exercise TemporarySaveExercise(BlEntities.Exercise exercise)
        {
            if (exercise == null)
            {
                this.logger.LogError("Exercise is null");
                throw new BlValidationException("Exercise is null", null);
            }
            else
            {
                try
                {
                    if (exercise.Created == null || (exercise.ExerciseVersion?.First()?.VersionNumber ?? 0) < 1)
                    {
                        exercise.Created = DateTime.Now;
                    }

                    var dalExercise = this.mapper.Map<DalEntities.Exercise>(exercise);

                    this.logger.LogInformation("BL passing Exercise with Title: " + exercise.Title + " to DAL.");
                    var dalNewExercise = this.exerciseRepository.TemporarySave(dalExercise);
                    var blNewExercise = this.mapper.Map<BlEntities.Exercise>(dalNewExercise);
                    return blNewExercise;
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    throw new BlDataAccessException("Unable to temporarily save Exercise with Title: " + exercise.Title + " to DAL.", e);
                }
            }
        }

        /// <inheritdoc/>
        public void ValidateExercise(BlEntities.Exercise exercise, int exerciseId, int exerciseVersion)
        {
            if (exercise == null)
            {
                this.logger.LogError("Exercise is null");
                throw new BlValidationException("Exercise is null", null);
            }
            else
            {
                try
                {
                    IValidator<BlEntities.Exercise> validator = new ExerciseValidator();
                    var validationResult = validator.Validate(exercise);

                    if (validationResult.IsValid)
                    {
                        this.exerciseRepository.UpdateValidState(exerciseId, exerciseVersion, DalEntities.ValidState.Valid);
                        this.logger.LogInformation("BL Exercise with Title: " + exercise.Title + " is valid");
                    }
                    else
                    {
                        this.exerciseRepository.UpdateValidState(exerciseId, exerciseVersion, DalEntities.ValidState.NotValid);
                        this.logger.LogInformation("BL Exercise with Title: " + exercise.Title + " is not valid");
                    }
                }
                catch (ValidationException e)
                {
                    this.logger.LogError(e.Message);
                    throw new BlValidationException("BL received invalid Exercise with Title : " + exercise.Title, e);
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    throw new BlDataAccessException("Unable to validate Exercise with Title: " + exercise.Title + " to DAL.", e);
                }
            }
        }

        /// <inheritdoc/>
        public List<BlEntities.MinimalExercise> SearchAndFilter(BlEntities.SearchObject searchObject)
        {
            if (searchObject == null)
            {
                this.logger.LogError("Search Object is null");
                throw new BlValidationException("Search Object is null", null);
            }
            else
            {
                try
                {
                    this.logger.LogInformation($"BL searching for Exercises, Search Term {searchObject.SearchTerm}, Programming Language {searchObject.ProgrammingLanguage} and Written Language {searchObject.WrittenLanguage}.");
                    var dalExerciseList = this.exerciseRepository.SearchAndFilter(searchObject.SearchTerm, searchObject.ProgrammingLanguage, searchObject.WrittenLanguage);
                    var blExerciseList = this.mapper.Map<List<BlEntities.MinimalExercise>>(dalExerciseList);

                    return blExerciseList;
                }
                catch (Exception e)
                {
                    this.logger.LogError(e.Message);
                    throw new BlDataAccessException($"Unable to search for exercises with Search Term {searchObject.SearchTerm}, Programming Language {searchObject.ProgrammingLanguage} and Written Language {searchObject.WrittenLanguage}.", e);
                }
            }
        }
    }
}
