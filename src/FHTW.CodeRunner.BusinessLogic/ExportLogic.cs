// <copyright file="ExportLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using FHTW.CodeRunner.ExportService.Interfaces;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    /// <summary>
    /// Logic Class for dealing with export actions.
    /// </summary>
    public class ExportLogic : IExportLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExerciseRepository exerciseRepository;
        private readonly ICollectionRepository collectionRepository;
        private readonly IMoodleXmlService moodleXmlService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportLogic"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected mapper.</param>
        /// <param name="exerciseRepository">The injected exercise repository.</param>
        /// <param name="collectionRepository">The injected collection repository.</param>
        /// <param name="moodleXmlService">The injected moodle xml service.</param>
        public ExportLogic(ILogger<ExportLogic> logger, IMapper mapper, IExerciseRepository exerciseRepository, ICollectionRepository collectionRepository, IMoodleXmlService moodleXmlService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
            this.collectionRepository = collectionRepository;
            this.moodleXmlService = moodleXmlService;
        }

        /// <inheritdoc/>
        public string ExportCollection(BlEntities.CollectionKeys collectionKeys)
        {
            if (collectionKeys == null)
            {
                this.logger.LogError("CollectionKeys is null");
                throw new BlValidationException("CollectionKeys is null", null);
            }

            try
            {
                var dalCollectionInstance = this.collectionRepository.GetCollectionInstance(
                collectionKeys.Id,
                collectionKeys.WrittenLanguage,
                collectionKeys.UseSetLanguage);

                var blCollectionInstance = this.mapper.Map<BlEntities.ExerciseInstance>(dalCollectionInstance);

                var quiz = this.mapper.Map<EsEntities.Quiz>(blCollectionInstance);

                return this.moodleXmlService.ExportMoodleXml(quiz);
            }
            catch (DalException e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataNotFoundException("Getting Collection Instance failed for Collection with Id: " + collectionKeys.Id, e);
            }
        }

        /// <inheritdoc/>
        public string ExportExercise(BlEntities.ExerciseKeys exerciseKeys)
        {
            if (exerciseKeys == null)
            {
                this.logger.LogError("ExerciseKeys is null");
                throw new BlValidationException("ExerciseKeys is null", null);
            }

            try
            {
                var dalExerciseInstance = this.exerciseRepository.GetExerciseInstance(
                exerciseKeys.Id,
                exerciseKeys.ProgrammingLanguage,
                exerciseKeys.WrittenLanguage,
                exerciseKeys.Version);

                var blExerciseInstance = this.mapper.Map<BlEntities.ExerciseInstance>(dalExerciseInstance);

                var blCollectionInstance = new BlEntities.CollectionInstance
                {
                    Exercises = new List<BlEntities.ExerciseInstance>(),
                };

                blCollectionInstance.Exercises.Add(blExerciseInstance);

                var quiz = this.mapper.Map<EsEntities.Quiz>(blCollectionInstance);

                return this.moodleXmlService.ExportMoodleXml(quiz);
            }
            catch (DalException e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataNotFoundException("Getting Exercise Instance failed for Exercise with Id: " + exerciseKeys.Id, e);
            }
        }
    }
}
