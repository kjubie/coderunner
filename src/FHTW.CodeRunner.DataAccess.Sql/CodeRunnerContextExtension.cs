// <copyright file="CodeRunnerContextExtension.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    public static class CodeRunnerContextExtension
    {
        public static bool AllMigrationsApplied(this CodeRunnerContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this CodeRunnerContext context)
        {
            if (!context.User.Any())
            {
                var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + "user.json"));
                context.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
