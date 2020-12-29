// <copyright file="ExportLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.ExportService.Interfaces;
using Microsoft.Extensions.Logging;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.BusinessLogic
{
    public class ExportLogic : IExportLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IExerciseRepository exerciseRepository;
        private readonly IMoodleXmlService moodleXmlService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportLogic"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="moodleXmlService"></param>
        public ExportLogic(ILogger<ExportLogic> logger, IMapper mapper, IExerciseRepository exerciseRepository, IMoodleXmlService moodleXmlService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.exerciseRepository = exerciseRepository;
            this.moodleXmlService = moodleXmlService;
        }

        public void ExportCollection(BlEntities.Collection collection)
        {
            throw new NotImplementedException();
        }

        public string ExportExercise(BlEntities.ExportExercise exportExercise)
        {
            var dalExerciseInstance = this.exerciseRepository.GetExerciseInstance(exportExercise.Id, exportExercise.ProgrammingLanguage, exportExercise.WrittenLanguage, exportExercise.Version);
            var blExerciseInstance = this.mapper.Map<BlEntities.ExerciseInstance>(dalExerciseInstance);

            var blCollectionInstance = new BlEntities.CollectionInstance
            {
                Exercises = new List<BlEntities.ExerciseInstance>(),
            };

            blCollectionInstance.Exercises.Add(blExerciseInstance);

            var quiz = this.mapper.Map<EsEntities.Quiz>(blCollectionInstance);

            return this.moodleXmlService.ExportMoodleXml(quiz);
        }
    }
}
