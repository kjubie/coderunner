// <copyright file="DbTestController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

﻿using System;
﻿using FHTW.CodeRunner.DataAccess.Entities;
﻿using FHTW.CodeRunner.DataAccess.Sql;
﻿using Microsoft.EntityFrameworkCore;

﻿namespace FHTW.CodeRunner.DataAccess.Tests
{
    /// <summary>
    /// Test Db Controller that sets up the database.
    /// </summary>
    public class DbTestController
    {
        public readonly DbContextOptions<CodeRunnerContext> contextOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTestController"/> class.
        /// </summary>
        /// <param name="options">options for the test db.</param>
        protected DbTestController(DbContextOptions<CodeRunnerContext> options)
        {
            this.ContextOptions = options;

            this.Seed();
        }

        /// <summary>
        /// Gets the db options used for the test db.
        /// </summary>
        public DbContextOptions<CodeRunnerContext> ContextOptions { get; }

        private void Seed()
        {
            using var context = new CodeRunnerContext(this.ContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var user = TestDataBuilder.Benutzer();

            context.SaveChanges();
        }
    }
}
