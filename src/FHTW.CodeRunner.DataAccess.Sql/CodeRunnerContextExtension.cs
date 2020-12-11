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
            var options = new JsonSerializerOptions()
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
            };

            using var transaction = context.Database.BeginTransaction();

            try
            {
                UpdateOrAdd<User>(context, "user", options);
                UpdateOrAdd<Exercise>(context, "exercise", options);
                UpdateOrAdd<ExerciseVersion>(context, "exercise_version", options);
                UpdateOrAdd<Comment>(context, "comment", options);
                UpdateOrAdd<Difficulty>(context, "difficulty", options);
                UpdateOrAdd<ExerciseHeader>(context, "exercise_header", options);
                UpdateOrAdd<Tag>(context, "tag", options);
                UpdateOrAdd<ExerciseTag>(context, "exercise_tag", options);
                UpdateOrAdd<WrittenLanguage>(context, "written_language", options);
                UpdateOrAdd<ProgrammingLanguage>(context, "programming_language", options);
                UpdateOrAdd<TestSuite>(context, "testsuite", options);
                UpdateOrAdd<TestCase>(context, "testcase", options);
                UpdateOrAdd<ExerciseLanguage>(context, "exercise_language", options);
                UpdateOrAdd<ExerciseBody>(context, "exercise_body", options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

            transaction.Commit();
        }

        private static void UpdateOrAdd<T>(CodeRunnerContext context, string name, JsonSerializerOptions options)
            where T : class
        {
            var list = JsonSerializer.Deserialize<List<T>>(File.ReadAllText("seed" + Path.DirectorySeparatorChar + name + ".json"), options);
            var table = context.Set<T>();

            list.ForEach(o =>
            {
                if (!context.Set<T>().Any(e => e == o))
                {
                    context.Add(o);
                }
                else
                {
                    context.Update(o);
                }

                context.SaveChanges();
            });
        }
    }
}
