// <copyright file="ExerciseLogicTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using AutoMapper;
using FHTW.CodeRunner.BusinessLogic;
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
    public class ExerciseLogicTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SaveExercise_ValidExercise_NoException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<IExerciseLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, DalEntities.Exercise>().ReverseMap();
                    cfg.CreateMap<BlEntities.User, DalEntities.User>().ReverseMap();
                }));

            var repoMock = new Mock<IExerciseRepository>();
            repoMock.Setup(p => p.SaveExercise(It.IsAny<DalEntities.Exercise>()));

            IExerciseRepository repo = repoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, repo);

            var validExercise = Builder<BlEntities.Exercise>
                .CreateNew()
                .With(e => e.FkUser = new BlEntities.User() { Name = "Hans" })
                .Build();

            // Act
            // Assert
            Assert.DoesNotThrow(() => logic.SaveExercise(validExercise));
        }

        [Test]
        public void SaveExercise_InvalidExercise_ValidationException()
        {
            // Arrange
            var logger = Mock.Of<ILogger<IExerciseLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, DalEntities.Exercise>().ReverseMap();
                }));

            var repoMock = new Mock<IExerciseRepository>();
            repoMock.Setup(p => p.SaveExercise(It.IsAny<DalEntities.Exercise>()));

            IExerciseRepository repo = repoMock.Object;

            IExerciseLogic logic = new ExerciseLogic(logger, mapper, repo);

            var validExercise = Builder<BlEntities.Exercise>
                .CreateNew()
                .Build();

            // Act
            // Assert
            Assert.Throws<FluentValidation.ValidationException>(() => logic.SaveExercise(validExercise));
        }
    }
}
