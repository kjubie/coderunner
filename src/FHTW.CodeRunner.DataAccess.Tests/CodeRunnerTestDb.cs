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
        public CodeRunnerTestDb(State state)
            : base(
                  new DbContextOptionsBuilder<CodeRunnerContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options,
                  state)
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


    }
}
