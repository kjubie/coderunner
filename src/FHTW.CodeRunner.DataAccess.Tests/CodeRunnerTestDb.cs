// <copyright file="CodeRunnerTestDb.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Data.Common;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    /// <summary>
    /// The in memory database for testing.
    /// </summary>
    public class CodeRunnerTestDb : DbTestController, IDisposable
    {
        private readonly DbConnection connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeRunnerTestDb"/> class.
        /// </summary>
        /// <param name="state">The requestet state of the test db.</param>
        private CodeRunnerTestDb(DbContextOptions<CodeRunnerContext> options, State state)
            : base(options, state)
        {
            this.connection = RelationalOptionsExtension.Extract(this.ContextOptions).Connection;
        }

        /// <summary>
        /// Closes the connection which deletes the test db.
        /// </summary>
        public void Dispose() => this.connection.Close();

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        /// <summary>
        /// Creates the test db in memory.
        /// </summary>
        /// <param name="state">The requestet state of the test db.</param>
        /// <returns>A new instance of the <see cref="CodeRunnerTestDb"/> class.</returns>
        public static CodeRunnerTestDb AsInMemoryDb(State state)
        {
            return new CodeRunnerTestDb(
                new DbContextOptionsBuilder<CodeRunnerContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options, state);
        }

        /// <summary>
        /// Creates a real test database.
        /// </summary>
        /// <param name="state">The requestet state of the test db.</param>
        /// <returns>A new instance of the <see cref="CodeRunnerTestDb"/> class.</returns>
        public static CodeRunnerTestDb AsRealTestDb(State state)
        {
            return new CodeRunnerTestDb(
                new DbContextOptionsBuilder<CodeRunnerContext>()
                    .UseNpgsql("Host=localhost;Database=coderunnerdb;Username=postgres;Password=admin;Port=5555")
                    .Options, state);
        }
    }
}
