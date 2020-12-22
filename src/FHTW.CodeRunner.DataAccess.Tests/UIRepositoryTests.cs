// <copyright file="ExerciseRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Testnames should be explanation enough.")]
    [TestFixture]
    public class UIRepositoryTests
    {
        private CodeRunnerTestDb testDb;
        private ILogger<UIRepository> logger;

        [OneTimeSetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

            this.logger = loggerFactory.CreateLogger<UIRepository>();
        }

        [TearDown]
        public void NullDatabase() => this.testDb = null;

        [Test]
        public void ShouldGetProgrammingLanguages()
        {
            this.SetupDatabaseSeeded();
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IUIRepository rep = new UIRepository(context, this.logger);

                var programming_languages = rep.GetProgrammingLanguages();

                Assert.IsNotNull(programming_languages);
                Assert.IsTrue(programming_languages.Count == CodeRunnerTestDb.PROGRAMMINGLANUGAGESCOUNT);
            }
        }

        [Test]
        public void ShouldGetWrittenLanguages()
        {
            this.SetupDatabaseSeeded();
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IUIRepository rep = new UIRepository(context, this.logger);

                var written_languages = rep.GetWrittenLanguages();

                Assert.IsNotNull(written_languages);
                Assert.IsTrue(written_languages.Count == CodeRunnerTestDb.WRITTENLANUGAGESCOUNT);
            }
        }

        [Test]
        public void ShouldGetQuestionTypes()
        {
            this.SetupDatabaseSeeded();
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IUIRepository rep = new UIRepository(context, this.logger);

                var questionTypes = rep.GetQuestionTypes();

                Assert.IsNotNull(questionTypes);
                Assert.IsTrue(questionTypes.Count == CodeRunnerTestDb.QUESTIONTYPESCOUNT);
            }
        }

        private void SetupDatabaseEmpty() => this.testDb = new CodeRunnerTestDb(DbTestController.State.EMPTY);

        private void SetupDatabaseSeeded() => this.testDb = new CodeRunnerTestDb(DbTestController.State.SEEDED);
    }
}
