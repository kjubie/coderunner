using FHTW.CodeRunner.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    class CodeRunnerTestDb : DbTestController, IDisposable
    {
        private readonly DbConnection connection;


        public CodeRunnerTestDb()
            :base(new DbContextOptionsBuilder<CodeRunnerContext>()
                    .UseSqlite(CreateInMemoryDatabase())
                    .Options)
        {
            connection = RelationalOptionsExtension.Extract(contextOptions).Connection;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }

        public void Dispose() => connection.Close();
    }
}
