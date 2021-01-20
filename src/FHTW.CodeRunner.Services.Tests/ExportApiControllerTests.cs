// <copyright file="ExportApiControllerTests.cs" company="FHTW CodeRunner">
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
    /// <summary>
    /// Unit Tests for Export Api Controller.
    /// </summary>
    public class ExportApiControllerTests
    {
        // TODO: Test for Content Type

        /// <summary>
        /// Testing the function ExportExercise.
        /// </summary>
        [Test]
        public void ExportExercise_ValidExportExercise_Ok()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExportApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SvcEntities.ExerciseKeys, BlEntities.ExerciseKeys>();
                }));

            var logicMock = new Mock<IExportLogic>();
            logicMock.Setup(p => p.ExportExercise(It.IsAny<BlEntities.ExerciseKeys>())).Returns("xml");

            IExportLogic logic = logicMock.Object;
            ExportApiController controller = new ExportApiController(logger, mapper, logic);

            var exportExercise = Builder<SvcEntities.ExerciseKeys>
                .CreateNew()
                .Build();

            // Act
            var response = controller.ExportExercise(exportExercise);

            // Assert
            Assert.IsInstanceOf<ContentResult>(response);
        }

        /// <summary>
        /// Testing the function ExportExercise.
        /// </summary>
        [Test]
        public void ExportExercise_NullExportExercise_BadRequest()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExportApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SvcEntities.ExerciseKeys, BlEntities.ExerciseKeys>();
                }));

            var logicMock = new Mock<IExportLogic>();
            logicMock.Setup(p => p.ExportExercise(It.IsAny<BlEntities.ExerciseKeys>())).Returns("xml");

            IExportLogic logic = logicMock.Object;
            ExportApiController controller = new ExportApiController(logger, mapper, logic);

            SvcEntities.ExerciseKeys exportExercise = null;

            // Act
            var response = controller.ExportExercise(exportExercise);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }
    }
}
