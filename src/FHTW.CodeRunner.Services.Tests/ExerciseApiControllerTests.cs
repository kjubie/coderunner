// <copyright file="ExerciseApiControllerTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.Services;
using FHTW.CodeRunner.Services.Controllers;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.Tests
{
    public class ExerciseApiControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetExerciseCreatePreparation_Ok()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.ExerciseCreatePreparation, SvcEntities.ExerciseCreatePreparation>();
                }));

            var logicMock = new Mock<IExerciseLogic>();

            var exerciseCreatePreparation = Builder<BlEntities.ExerciseCreatePreparation>
                .CreateNew()
                .Build();

            logicMock.Setup(p => p.GetExerciseCreatePreparation()).Returns(exerciseCreatePreparation);

            IExerciseLogic logic = logicMock.Object;
            ExerciseApiController controller = new ExerciseApiController(logger, mapper, logic);

            // Act
            var response = controller.GetExerciseCreatePreparation();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void SaveExercise_ValidExercise_Ok()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, SvcEntities.Exercise>().ReverseMap();
                    cfg.CreateMap<BlEntities.User, SvcEntities.User>().ReverseMap();
                }));

            var logicMock = new Mock<IExerciseLogic>();
            logicMock.Setup(p => p.SaveExercise(It.IsAny<BlEntities.Exercise>()));

            IExerciseLogic logic = logicMock.Object;
            ExerciseApiController controller = new ExerciseApiController(logger, mapper, logic);

            var exercise = Builder<SvcEntities.Exercise>
                .CreateNew()
                .Build();

            // Act
            var response = controller.SaveExercise(exercise);

            // Assert
            Assert.IsInstanceOf<OkResult>(response);
        }

        [Test]
        public void SaveExercise_NullExercise_BadRequest()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExerciseApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.Exercise, SvcEntities.Exercise>().ReverseMap();
                }));

            var logicMock = new Mock<IExerciseLogic>();
            logicMock.Setup(p => p.SaveExercise(It.IsAny<BlEntities.Exercise>()));

            IExerciseLogic logic = logicMock.Object;
            ExerciseApiController controller = new ExerciseApiController(logger, mapper, logic);

            SvcEntities.Exercise exercise = null;

            // Act
            var response = controller.SaveExercise(exercise);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }
    }
}
