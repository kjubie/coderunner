// <copyright file="DatabaseSeeder.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// A service that seeds the database with test data.
    /// </summary>
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly bool debugConfiguration;
        private readonly ILogger logger;
        private readonly CodeRunnerContext context;

        public DatabaseSeeder(ILogger<DatabaseSeeder> logger, CodeRunnerContext context)
        {
            this.debugConfiguration = false;
            this.logger = logger;
            this.context = context;
            #if DEBUG
            this.debugConfiguration = true;
            #endif
        }

        public void Seed()
        {
            Console.WriteLine("SEEDING");
        }
    }
}
