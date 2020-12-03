// <copyright file="ExerciseRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using NUnit.Framework;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Testnames should be explanation enough.")]
    [TestFixture]
    public class UserRepositoryTests
    {
        private CodeRunnerTestDb testDb;

        [TearDown]
        public void NullDatabase() => this.testDb = null;

        [Test]
        public void ShouldInsertUser()
        {
            this.SetupDatabaseEmpty();
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IUserRepository rep = new UserRepository(context);

                User user = TestDataBuilder<User>.Single();

                rep.Insert(user);

                Assert.IsTrue(rep.Exists(user));
            }
        }

        [Test]
        public void ShouldAuthenticateUser()
        {
            this.SetupDatabaseSeeded();
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IUserRepository rep = new UserRepository(context);

                User user = TestDataBuilder<User>.Single();

                Assert.IsTrue(rep.Authenticate(user));
            }
        }

        private void SetupDatabaseEmpty() => this.testDb = new CodeRunnerTestDb(DbTestController.State.EMPTY);

        private void SetupDatabaseSeeded() => this.testDb = new CodeRunnerTestDb(DbTestController.State.SEEDED);
    }
}