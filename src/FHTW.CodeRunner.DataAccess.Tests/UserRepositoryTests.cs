// <copyright file="ExerciseRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            this.SetupDatabaseInMemory(DbTestController.State.EMPTY);
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
            this.SetupDatabaseInMemory(DbTestController.State.SEEDED);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IUserRepository rep = new UserRepository(context);

                User user = TestDataBuilder<User>.Single();

                var r = rep.Authenticate(user);

                Assert.IsNotNull(r);
            }
        }

        private void SetupDatabaseReal(DbTestController.State state) => this.testDb = CodeRunnerTestDb.AsRealTestDb(state);

        private void SetupDatabaseInMemory(DbTestController.State state) => this.testDb = CodeRunnerTestDb.AsInMemoryDb(state);
    }
}
