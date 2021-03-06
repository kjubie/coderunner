// <copyright file="ExportLogicTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using AutoMapper;
using FHTW.CodeRunner.BusinessLogic;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using FHTW.CodeRunner.ExportService.Interfaces;
using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Tests
{
    /// <summary>
    /// Unit tests for Export Logic.
    /// </summary>
    public class ExportLogicTests
    {
        /// <summary>
        /// Testing the function ExportExercise.
        /// </summary>
        [Test]
        public void ExportExercise_ExportExercise_BlValidationException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExportLogic>>();
            const string xmlString = "xml";

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DalEntities.ExerciseInstance, BlEntities.ExerciseInstance>();
                    cfg.CreateMap<BlEntities.CollectionInstance, EsEntities.Quiz>();
                }));

            var exerciseInstance = Builder<DalEntities.ExerciseInstance>
                .CreateNew()
                .Build();

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.GetExerciseInstance(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(exerciseInstance);

            var collectionRepoMock = new Mock<ICollectionRepository>();

            var moodleXmlServiceMock = new Mock<IMoodleXmlService>();
            moodleXmlServiceMock.Setup(p => p.ExportMoodleXml(It.IsAny<EsEntities.Quiz>())).Returns(xmlString);

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            ICollectionRepository collectionRepo = collectionRepoMock.Object;
            IMoodleXmlService moodleXmlService = moodleXmlServiceMock.Object;

            IExportLogic logic = new ExportLogic(logger, mapper, exerciseRepo, collectionRepo, moodleXmlService);

            BlEntities.ExerciseKeys nullExportExercise = null;

            // Act
            // Assert
            Assert.Throws<BlValidationException>(() => logic.ExportExercise(nullExportExercise));
        }

        /// <summary>
        /// Testing the function ExportExercise.
        /// </summary>
        [Test]
        public void ExportExercise_InvalidExerciseInstance_BlDataAccessException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExportLogic>>();
            const string xmlString = "xml";

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DalEntities.ExerciseInstance, BlEntities.ExerciseInstance>();
                    cfg.CreateMap<BlEntities.CollectionInstance, EsEntities.Quiz>();
                }));

            var exerciseInstance = Builder<DalEntities.ExerciseInstance>
                .CreateNew()
                .Build();

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.GetExerciseInstance(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Throws(new DalException("Unit Test"));

            var collectionRepoMock = new Mock<ICollectionRepository>();

            var moodleXmlServiceMock = new Mock<IMoodleXmlService>();
            moodleXmlServiceMock.Setup(p => p.ExportMoodleXml(It.IsAny<EsEntities.Quiz>())).Returns(xmlString);

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            ICollectionRepository collectionRepo = collectionRepoMock.Object;
            IMoodleXmlService moodleXmlService = moodleXmlServiceMock.Object;

            IExportLogic logic = new ExportLogic(logger, mapper, exerciseRepo, collectionRepo, moodleXmlService);

            BlEntities.ExerciseKeys exportExercise = Builder<BlEntities.ExerciseKeys>
                .CreateNew()
                .Build();

            // Act
            // Assert
            Assert.Throws<BlDataNotFoundException>(() => logic.ExportExercise(exportExercise));
        }

        /// <summary>
        /// Testing the function ExportExercise.
        /// </summary>
        [Test]
        public void ExportExercise_ValidExportExercise_NotNull()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExportLogic>>();
            const string xmlString = "xml";

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DalEntities.ExerciseInstance, BlEntities.ExerciseInstance>();
                    cfg.CreateMap<BlEntities.CollectionInstance, EsEntities.Quiz>();
                }));

            var exerciseInstance = Builder<DalEntities.ExerciseInstance>
                .CreateNew()
                .Build();

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.GetExerciseInstance(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>())).Returns(exerciseInstance);

            var collectionRepoMock = new Mock<ICollectionRepository>();

            var moodleXmlServiceMock = new Mock<IMoodleXmlService>();
            moodleXmlServiceMock.Setup(p => p.ExportMoodleXml(It.IsAny<EsEntities.Quiz>())).Returns(xmlString);

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            ICollectionRepository collectionRepo = collectionRepoMock.Object;
            IMoodleXmlService moodleXmlService = moodleXmlServiceMock.Object;

            IExportLogic logic = new ExportLogic(logger, mapper, exerciseRepo, collectionRepo, moodleXmlService);

            BlEntities.ExerciseKeys exportExercise = Builder<BlEntities.ExerciseKeys>
                .CreateNew()
                .Build();

            // Act
            string result = logic.ExportExercise(exportExercise);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(xmlString, result);
        }
    }
}
