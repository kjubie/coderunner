// <copyright file="ExerciseLogicTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using AutoMapper;
using FHTW.CodeRunner.BusinessLogic;
using FHTW.CodeRunner.BusinessLogic.Exceptions;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FizzWare.NBuilder;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Tests
{
    /// <summary>
    /// Unit Tests for the Exercise Logic.
    /// </summary>
    public class ExerciseLogicTests
    {
        /// <summary>
        /// Testing the function GetExerciseShortList.
        /// </summary>
        [Test]
        public void GetExerciseShortList_CorrectCount()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseLogic>>();
            const int count = 5;

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DalEntities.MinimalExercise, BlEntities.MinimalExercise>();
                }));

            var exerciseShortList = new System.Collections.Generic.List<DalEntities.MinimalExercise>(Builder<DalEntities.MinimalExercise>
                .CreateListOfSize(count)
                .Build());

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.GetMinimalList()).Returns(exerciseShortList);

            var uiRepoMock = new Mock<IUIRepository>();

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            IUIRepository uiRepo = uiRepoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, exerciseRepo, uiRepo);

            // Act
            var result = logic.GetMinimalExerciseList();

            // Assert
            Assert.AreEqual(count, result.Count);
        }

        /// <summary>
        /// Testing the function GetExerciseCreatePreparation.
        /// </summary>
        [Test]
        public void GetExerciseCreatePreparation_NotNull()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseLogic>>();
            const int count = 5;

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DalEntities.ProgrammingLanguage, BlEntities.ProgrammingLanguage>();
                    cfg.CreateMap<DalEntities.WrittenLanguage, BlEntities.WrittenLanguage>();
                    cfg.CreateMap<DalEntities.QuestionType, BlEntities.QuestionType>();
                }));

            var programmingLanguageList = new System.Collections.Generic.List<DalEntities.ProgrammingLanguage>(Builder<DalEntities.ProgrammingLanguage>
                .CreateListOfSize(count)
                .Build());

            var writtenLanguageList = new System.Collections.Generic.List<DalEntities.WrittenLanguage>(Builder<DalEntities.WrittenLanguage>
                .CreateListOfSize(count)
                .Build());

            var questionTypeList = new System.Collections.Generic.List<DalEntities.QuestionType>(Builder<DalEntities.QuestionType>
                .CreateListOfSize(count)
                .Build());

            var exerciseRepoMock = new Mock<IExerciseRepository>();

            var uiRepoMock = new Mock<IUIRepository>();
            uiRepoMock.Setup(p => p.GetProgrammingLanguages()).Returns(programmingLanguageList);
            uiRepoMock.Setup(p => p.GetWrittenLanguages()).Returns(writtenLanguageList);
            uiRepoMock.Setup(p => p.GetQuestionTypes()).Returns(questionTypeList);

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            IUIRepository uiRepo = uiRepoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, exerciseRepo, uiRepo);

            // Act
            var result = logic.GetExerciseCreatePreparation();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(count, result.ProgrammingLanguages.Count);
            Assert.AreEqual(count, result.WrittenLanguages.Count);
            Assert.AreEqual(count, result.QuestionTypes.Count);
        }

        /// <summary>
        /// Testing the function SaveExercise.
        /// </summary>
        [Test]
        public void SaveExercise_ValidExercise_NoException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, DalEntities.Exercise>();
                    cfg.CreateMap<BlEntities.User, DalEntities.User>();
                }));

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.Save(It.IsAny<DalEntities.Exercise>()));

            var uiRepoMock = new Mock<IUIRepository>();

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            IUIRepository uiRepo = uiRepoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, exerciseRepo, uiRepo);

            var validExercise = Builder<BlEntities.Exercise>
                .CreateNew()
                .With(e => e.FkUser = new BlEntities.User() { Name = "Hans" })
                .Build();

            // Act
            // Assert
            Assert.DoesNotThrow(() => logic.SaveExercise(validExercise));
        }

        /// <summary>
        /// Testing the function SaveExercise.
        /// </summary>
        [Test]
        public void SaveExercise_NullExercise_BlValidationException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, DalEntities.Exercise>();
                }));

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.Save(It.IsAny<DalEntities.Exercise>()));

            var uiRepoMock = new Mock<IUIRepository>();

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            IUIRepository uiRepo = uiRepoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, exerciseRepo, uiRepo);

            BlEntities.Exercise nullExercise = null;

            // Act
            // Assert
            Assert.Throws<BlValidationException>(() => logic.SaveExercise(nullExercise));
        }

        /// <summary>
        /// Testing the function ValidateExercise.
        /// </summary>
        [Test]
        public void ValidateExercise_ValidExercise_NoException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, DalEntities.Exercise>();
                    cfg.CreateMap<BlEntities.User, DalEntities.User>();
                }));

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.Save(It.IsAny<DalEntities.Exercise>()));

            var uiRepoMock = new Mock<IUIRepository>();

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            IUIRepository uiRepo = uiRepoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, exerciseRepo, uiRepo);

            var validExercise = Builder<BlEntities.Exercise>
                .CreateNew()
                .With(e => e.FkUser = new BlEntities.User() { Name = "Hans" })
                .Build();

            // Act
            // Assert
            Assert.DoesNotThrow(() => logic.ValidateExercise(validExercise));
        }

        /// <summary>
        /// Testing the function ValidateExercise.
        /// </summary>
        [Test]
        public void ValidateExercise_NullExercise_ValidationException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, DalEntities.Exercise>();
                }));

            var exerciseRepoMock = new Mock<IExerciseRepository>();
            exerciseRepoMock.Setup(p => p.Save(It.IsAny<DalEntities.Exercise>()));

            var uiRepoMock = new Mock<IUIRepository>();

            IExerciseRepository exerciseRepo = exerciseRepoMock.Object;
            IUIRepository uiRepo = uiRepoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, exerciseRepo, uiRepo);

            BlEntities.Exercise nullExercise = null;

            // Act
            // Assert
            Assert.Throws<BlValidationException>(() => logic.ValidateExercise(nullExercise));
        }
    }
}
