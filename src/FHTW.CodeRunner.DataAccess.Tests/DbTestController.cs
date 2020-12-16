// <copyright file="DbTestController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

﻿using System;
﻿using System.Diagnostics;
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
        /// <summary>
        /// The ammount of programming languages in the test database.
        /// </summary>
        public static readonly int PROGRAMMINGLANUGAGESCOUNT = 3;

        /// <summary>
        /// The ammount of written languages in the test database.
        /// </summary>
        public static readonly int WRITTENLANUGAGESCOUNT = 3;

        private readonly DbContextOptions<CodeRunnerContext> contextOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbTestController"/> class.
        /// </summary>
        /// <param name="options">options for the test db.</param>
        /// <param name="state">The requestet state of the test db.</param>
        protected DbTestController(DbContextOptions<CodeRunnerContext> options, State state)
        {
            this.contextOptions = options;

            using var context = new CodeRunnerContext(this.ContextOptions);

            this.CreateDb(context);

            if (state == State.SEEDED)
            {
                this.Seed(context);
            }
        }

        /// <summary>
        /// The requestet state of the test db.
        /// </summary>
        public enum State
        {
            /// <summary>
            /// Test db should only contain the empty tables.
            /// </summary>
            EMPTY,

            /// <summary>
            /// Test db should contain test data.
            /// </summary>
            SEEDED,
        }

        /// <summary>
        /// Gets the db options used for the test db.
        /// </summary>
        public DbContextOptions<CodeRunnerContext> ContextOptions
        {
            get
            {
                return this.contextOptions;
            }
        }

        private void CreateDb(CodeRunnerContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.SaveChanges(); // necessarry ?
        }

        private void Seed(CodeRunnerContext context)
        {
            Debug.Assert(!context.Database.EnsureCreated(), "Seed() should be called after CreateDb()");

            var user = TestDataBuilder<User>.Single();
            context.Add(user);

            var language = TestDataBuilder<WrittenLanguage>.Many(WRITTENLANUGAGESCOUNT);
            context.AddRange(language);

            var programmingLanguage = TestDataBuilder<ProgrammingLanguage>.Many(PROGRAMMINGLANUGAGESCOUNT);
            context.AddRange(programmingLanguage);

            var tags= TestDataBuilder<Tag>.Many(10);
            context.AddRange(tags);

            context.SaveChanges();
        }
    }
}
