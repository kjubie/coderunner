using FHTW.CodeRunner.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    class DbTestController
    {
        public readonly DbContextOptions<CodeRunnerContext> contextOptions;
        protected DbTestController(DbContextOptions<CodeRunnerContext> options)
        {
            this.contextOptions = options;

            this.Populate();
        }

        private void Populate()
        {
            using var context = new CodeRunnerContext(this.contextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var user = new Benutzer();

            user.Name = "Hans";

            var exercise = new Exercise();

            exercise.Title = "Test Exercise";
            exercise.Created = new DateTime(2020, 5, 1, 8, 30, 52);
            exercise.FkUser = user;

            context.AddRange(user, exercise);

            context.SaveChanges();

        }
    }
}
