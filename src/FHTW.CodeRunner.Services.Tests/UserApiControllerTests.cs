// <copyright file="UserApiControllerTests.cs" company="FHTW CodeRunner">
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
    public class UserApiControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AuthenticateUser_ValidUserAuthentication_Ok()
        {
            // Arrange
            var logger = Mock.Of<ILogger<UserApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SvcEntities.UserAuthentication, BlEntities.User>();
                }));

            var logicMock = new Mock<IUserLogic>();
            logicMock.Setup(p => p.AuthenticateUser(It.IsAny<BlEntities.User>())).Returns(true);

            IUserLogic logic = logicMock.Object;
            UserApiController controller = new UserApiController(logger, mapper, logic);

            var userAuthentication = Builder<SvcEntities.UserAuthentication>
                .CreateNew()
                .Build();

            // Act
            var response = controller.AuthenticateUser(userAuthentication);

            // Assert
            Assert.IsInstanceOf<OkResult>(response);
        }

        [Test]
        public void AuthenticateUser_InvalidUserAuthentication_Ok()
        {
            // Arrange
            var logger = Mock.Of<ILogger<UserApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SvcEntities.UserAuthentication, BlEntities.User>();
                }));

            var logicMock = new Mock<IUserLogic>();
            logicMock.Setup(p => p.AuthenticateUser(It.IsAny<BlEntities.User>())).Returns(false);

            IUserLogic logic = logicMock.Object;
            UserApiController controller = new UserApiController(logger, mapper, logic);

            var userAuthentication = Builder<SvcEntities.UserAuthentication>
                .CreateNew()
                .Build();

            // Act
            var response = controller.AuthenticateUser(userAuthentication);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }

        [Test]
        public void AuthenticateUser_NullUserAuthentication_BadRequest()
        {
            // Arrange
            var logger = Mock.Of<ILogger<UserApiController>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SvcEntities.UserAuthentication, BlEntities.User>();
                }));

            var logicMock = new Mock<IUserLogic>();
            logicMock.Setup(p => p.AuthenticateUser(It.IsAny<BlEntities.User>()));

            IUserLogic logic = logicMock.Object;
            UserApiController controller = new UserApiController(logger, mapper, logic);

            SvcEntities.UserAuthentication userAuthentication = null;

            // Act
            var response = controller.AuthenticateUser(userAuthentication);

            // Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(response);
        }
    }
}
