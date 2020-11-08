// <copyright file="ExerciseRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using NUnit.Framework;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    public class ExerciseRepositoryTests
    {
        private CodeRunnerTestDb context;

        [SetUp]
        public void Setup()
        {
            this.context = new CodeRunnerTestDb();
        }

        [Test]
        public void Test1()
        {
            using var c = new CodeRunnerContext(this.context.contextOptions);

            // IExerciseRepository repo = new ExerciseRepository(c);

            // Exercise exercise = repo.GetExerciseById(1);
            var user = c.Benutzer.FirstOrDefault();
            Assert.IsNotNull(user);
            Assert.IsTrue(user.Name == "Hans");

            // Assert.IsNotNull(exercise.Title);
        }
    }
}
