// <copyright file="ExerciseRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using FHTW.CodeRunner.DataAccess.Entities;
using NUnit.Framework;
using System.Linq;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    public class ExerciseRepositoryTests
    {
        private CodeRunnerTestDb testDb;

        [SetUp]
        public void Setup()
        {
            this.testDb = new CodeRunnerTestDb();
        }

        [Test]
        public void Test1()
        {
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                Assert.IsTrue(true);
            }
        }
    }
}
