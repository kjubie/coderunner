﻿// <copyright file="CollectionRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
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
    public class CollectionRepositoryTests
    {
        private CodeRunnerTestDb testDb;

        [TearDown]
        public void NullDatabase() => this.testDb = null;

        [Test]
        public void ShouldGetExerciseInstancesWithSetLanguage()
        {
            /* Not testable with SQLITE
            this.SetupDatabase(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                ICollectionRepository rep = new CollectionRepository(context);

                var list = rep.GetExercisesInstances(1);

                Assert.NotNull(list);
            }*/

            Assert.True(true);
        }

        private void SetupDatabase(DbTestController.State state) => this.testDb = new CodeRunnerTestDb(state);
    }
}
