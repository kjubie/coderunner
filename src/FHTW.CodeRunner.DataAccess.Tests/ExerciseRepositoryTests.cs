using NUnit.Framework;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Sql;
using FHTW.CodeRunner.DataAccess.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    public class ExerciseRepositoryTests
    {
        private CodeRunnerTestDb context;

        [SetUp]
        public void Setup()
        {
            context = new CodeRunnerTestDb();
        }

        [Test]
        public void Test1()
        {
            using(var c = new CodeRunnerContext(context.contextOptions))
            {
                //IExerciseRepository repo = new ExerciseRepository(c);

                //Exercise exercise = repo.GetExerciseById(1);
                var user = c.Benutzer.FirstOrDefault();
                Assert.IsNotNull(user);
                Assert.IsTrue(user.Name == "Hans");
                //Assert.IsNotNull(exercise.Title);
            }
        }
    }
}