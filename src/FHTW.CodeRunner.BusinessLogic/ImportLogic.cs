// <copyright file="ImportLogic.cs" company="FHTW CodeRunner">
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
                var preparedImportData = this.mapper.Map<BlEntities.PreparedImportData>(importData);
                preparedImportData.Quiz = this.moodleXmlService.ImportMoodleXml(importData.XmlString);

                var collection = this.mapper.Map<BlEntities.Collection>(preparedImportData);

                if (collection.Created == null)
                {
                    collection.Created = DateTime.Now;
                }

                var dalCollection = this.mapper.Map<DalEntities.Collection>(collection);

                if (importData == null)
                {
                    this.logger.LogError("Collection conversion is not successful");
                    throw new BlDataNotFoundException("Collection is null", null);
                }

                foreach (var dalExercise in dalCollection.CollectionExercise)
                {
                    var savedDalExercise = this.exerciseRepository.CreateAndUpdate(dalExercise.FkExercise);
                    dalExercise.FkExerciseId = savedDalExercise.Id;
                }

                this.collectionRepository.CreateOrUpdate(dalCollection);
                this.logger.LogInformation("BL passing Collection with Title: " + collection.Title + " to DAL.");
            }
            catch (DalException e)
            {
                this.logger.LogError(e.Message);
                throw new BlDataAccessException("An error occured while importing the collection.", e);
            }
        }
    }
}
