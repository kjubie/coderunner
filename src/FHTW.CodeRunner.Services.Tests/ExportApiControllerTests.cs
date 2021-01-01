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
    public class ExportApiControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        // TODO: Test for Content Type
        [Test]
        public void ExportExercise_ValidExportExercise_Ok()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExportApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SvcEntities.ExportExercise, BlEntities.ExportExercise>();
                }));

            var logicMock = new Mock<IExportLogic>();
            logicMock.Setup(p => p.ExportExercise(It.IsAny<BlEntities.ExportExercise>())).Returns("xml");

            IExportLogic logic = logicMock.Object;
            ExportApiController controller = new ExportApiController(logger, mapper, logic);

            var exportExercise = Builder<SvcEntities.ExportExercise>
                .CreateNew()
                .Build();

            // Act
            var response = controller.ExportExercise(exportExercise);

            // Assert
            Assert.IsInstanceOf<ContentResult>(response);
        }

        [Test]
        public void ExportExercise_NullExportExercise_BadRequest()
        {
            // Arrange
            var logger = Mock.Of<ILogger<ExportApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SvcEntities.ExportExercise, BlEntities.ExportExercise>();
                }));

            var logicMock = new Mock<IExportLogic>();
            logicMock.Setup(p => p.ExportExercise(It.IsAny<BlEntities.ExportExercise>())).Returns("xml");

            IExportLogic logic = logicMock.Object;
            ExportApiController controller = new ExportApiController(logger, mapper, logic);

            SvcEntities.ExportExercise exportExercise = null;

            // Act
            var response = controller.ExportExercise(exportExercise);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }
    }
}
