using NUnit.Framework;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Sql;
using FHTW.CodeRunner.DataAccess.Interfaces;
using System;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    public class ExerciseRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IExerciseRepository repo = new ExerciseRepository(new CodeRunnerContext());
            Exercise exercise = repo.GetExerciseById(1);
            Assert.IsNotNull(exercise);
            Benutzer b = exercise.FkUser;
            Assert.IsNotNull(b);
            Assert.IsNotNull(b.Name);
            Console.WriteLine(b.Name);
        }
    }
}