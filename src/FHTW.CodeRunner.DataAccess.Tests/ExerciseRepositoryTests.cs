// <copyright file="ExerciseRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Testnames should be explanation enough.")]
    [TestFixture]
    public class ExerciseRepositoryTests
    {
        private CodeRunnerTestDb testDb;

        [SetUp]
        public void SetupShouldInsertExercise() => this.testDb = new CodeRunnerTestDb(DbTestController.State.SEEDED);

        [Test]
        public void ShouldInsertExercise()
        {
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IExerciseRepository rep = new ExerciseRepository(context);

                Exercise exercise = TestDataBuilder<Exercise>.Single();

                exercise.FkUser = context.Benutzer.FirstOrDefault();

                rep.Insert(exercise);

                Assert.IsTrue(rep.Exists(exercise));
            }
        }
    }
}
