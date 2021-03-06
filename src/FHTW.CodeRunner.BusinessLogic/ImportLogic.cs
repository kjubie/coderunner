// <copyright file="ImportLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using FHTW.CodeRunner.ExportService.Exceptions;
using FHTW.CodeRunner.ExportService.Interfaces;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    /// <summary>
    /// Logic Class for import actions.
    /// </summary>
    public class ImportLogic : IImportLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExerciseRepository exerciseRepository;
        private readonly ICollectionRepository collectionRepository;
        private readonly IMoodleXmlService moodleXmlService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportLogic"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected mapper.</param>
        /// <param name="exerciseRepository">The injected exercise repository.</param>
        /// <param name="collectionRepository">The injected collection repository.</param>
        /// <param name="moodleXmlService">The injected moodle xml service.</param>
        public ImportLogic(ILogger<ImportLogic> logger, IMapper mapper, IExerciseRepository exerciseRepository, ICollectionRepository collectionRepository, IMoodleXmlService moodleXmlService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
            this.collectionRepository = collectionRepository;
            this.moodleXmlService = moodleXmlService;
        }

        /// <inheritdoc/>
        public void ImportCollection(BlEntities.ImportData importData)
        {
            if (importData == null)
            {
                this.logger.LogError("ImportData is null");
                throw new BlValidationException("ImportData is null", null);
            }

            try
            {
                EsEntities.Quiz quiz = this.moodleXmlService.ImportMoodleXml(importData.XmlString);
                importData.XmlString = null;

                var collection = new BlEntities.Collection
                {
                    Id = 0,
                    Title = importData.Title,
                    Created = DateTime.Now,
                    FkUserId = importData.User.Id,
                    CollectionExercise = new List<BlEntities.CollectionExercise>(),
                    CollectionLanguage = new List<BlEntities.CollectionLanguage>(),
                };

                BlEntities.CollectionLanguage collectionLanguage = new BlEntities.CollectionLanguage
                {
                    Id = 0,
                    FullTitle = importData.Title,
                    ShortTitle = importData.Title,
                    Introduction = string.Empty,
                    FkWrittenLanguage = null,
                    FkWrittenLanguageId = importData.WrittenLanguage.Id,
                };

                collection.CollectionLanguage.Add(collectionLanguage);

                foreach (var question in quiz.Question)
                {
                    importData.Question = question;
                    if (question.Coderunnertype == null)
                    {
                        this.logger.LogError("Question Type is null");
                        throw new ValidationException("Question Type is null");
                    }

                    var dalQuestionType = this.exerciseRepository.GetQuestionType(question.Coderunnertype);

                    importData.ProgrammingLanguage = this.mapper.Map<BlEntities.ProgrammingLanguage>(dalQuestionType.FkProgrammingLanguage);
                    importData.QuestionType = this.mapper.Map<BlEntities.QuestionType>(dalQuestionType);

                    var blExercise = this.mapper.Map<BlEntities.Exercise>(importData);

                    var dalExercise = this.mapper.Map<DalEntities.Exercise>(blExercise);
                    var savedDalExercise = this.exerciseRepository.Save(dalExercise);

                    var collectionExercise = new BlEntities.CollectionExercise
                    {
                        Id = 0,
                        FkExerciseId = savedDalExercise.Id,
                        VersionNumber = 1,
                        FkWrittenLanguageId = importData.WrittenLanguage.Id,
                        FkProgrammingLanguageId = importData.ProgrammingLanguage.Id,
                    };

                    collection.CollectionExercise.Add(collectionExercise);
                }

                var dalCollection = this.mapper.Map<DalEntities.Collection>(collection);

                this.collectionRepository.CreateOrUpdate(dalCollection);
                this.logger.LogInformation("BL passing Collection with Title: " + collection.Title + " to DAL.");
            }
            catch (ValidationException e)
            {
                this.logger.LogError(e.Message);
                throw new BlValidationException("BL received collection with Title " + importData.Title + ".", e);
            }
            catch (ExportXmlConversionException e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("BL unable to import collection with Title " + importData.Title + ".", e);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("An error occured while importing the collection " + importData.Title + ".", e);
            }
        }
    }
}
