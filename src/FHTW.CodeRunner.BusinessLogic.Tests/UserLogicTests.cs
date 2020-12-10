﻿// <copyright file="UserLogicTests.cs" company="FHTW CodeRunner">
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
    public class UserLogicTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AuthenticateUser_ValidUser_True()
        {
            // Arrange
            var logger = Mock.Of<ILogger<UserLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.User, DalEntities.User>();
                }));

            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(p => p.Authenticate(It.IsAny<DalEntities.User>())).Returns(true);

            IUserRepository repo = repoMock.Object;

            IUserLogic logic = new UserLogic(logger, mapper, repo);

            var validUser = Builder<BlEntities.User>
                .CreateNew()
                .With(p => p.Name = "root")
                .And(p => p.Password = "toor")
                .Build();

            // Act
            bool result = logic.AuthenticateUser(validUser);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AuthenticateUser_InvalidUser_False()
        {
            // Arrange
            var logger = Mock.Of<ILogger<UserLogic>>();

            IMapper mapper = new Mapper(
                new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<BlEntities.User, DalEntities.User>();
                }));

            var repoMock = new Mock<IUserRepository>();
            repoMock.Setup(p => p.Authenticate(It.IsAny<DalEntities.User>())).Returns(false);

            IUserRepository repo = repoMock.Object;

            IUserLogic logic = new UserLogic(logger, mapper, repo);

            var validUser = Builder<BlEntities.User>
                .CreateNew()
                .Build();

            // Act
            bool result = logic.AuthenticateUser(validUser);

            // Assert
            Assert.IsFalse(result);
        }
    }
}