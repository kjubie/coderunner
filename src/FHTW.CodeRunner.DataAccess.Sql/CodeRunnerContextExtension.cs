// <copyright file="CodeRunnerContextExtension.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text.Json;
using System.Text.Json.Serialization;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// Extension to the CodeRunnerContext handling migration and seeding of the database.
    /// </summary>
    public static class CodeRunnerContextExtension
    {
        /// <summary>
        /// Checks if all migrations are applied.
        /// </summary>
        /// <param name="context">The context from this.</param>
        /// <returns>True if migrations are up to date, else false.</returns>
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

        /// <summary>
        /// Ensures that the database is seeded.
        /// In the current version it not only seeds the nessesary values like:
        ///     - WrittenLanguage
        ///     - ProgrammingLanguage
        ///     - QuestionType
        /// But also test exercises and collections.
        /// When changing the test data it might come to complications with the tests, because they might make assumptions about the available data.
        /// </summary>
        /// <param name="context">The context from this.</param>
        public static void EnsureSeeded(this CodeRunnerContext context)
        {
            var options = new JsonSerializerOptions()
            {
                ReadCommentHandling = JsonCommentHandling.Skip,
            };

            using var transaction = context.Database.BeginTransaction();

            try
            {
                UpdateOrAdd<User>(context, Properties.Resources.user, options);
                UpdateOrAdd<Exercise>(context, Properties.Resources.exercise, options);
                UpdateOrAdd<ExerciseVersion>(context, Properties.Resources.exercise_version, options);
                UpdateOrAdd<Comment>(context, Properties.Resources.comment, options);
                UpdateOrAdd<Difficulty>(context, Properties.Resources.difficulty, options);
                UpdateOrAdd<ExerciseHeader>(context, Properties.Resources.exercise_header, options);
                UpdateOrAdd<Tag>(context, Properties.Resources.tag, options);
                UpdateOrAdd<ExerciseTag>(context, Properties.Resources.exercise_tag, options);
                UpdateOrAdd<WrittenLanguage>(context, Properties.Resources.written_language, options);
                UpdateOrAdd<ProgrammingLanguage>(context, Properties.Resources.programming_language, options);
                UpdateOrAdd<QuestionType>(context, Properties.Resources.questiontype, options);
                UpdateOrAdd<TestSuite>(context, Properties.Resources.testsuite, options);
                UpdateOrAdd<TestCase>(context, Properties.Resources.testcase, options);
                UpdateOrAdd<ExerciseLanguage>(context, Properties.Resources.exercise_language, options);
                UpdateOrAdd<ExerciseBody>(context, Properties.Resources.exercise_body, options);
                UpdateOrAdd<Collection>(context, Properties.Resources.collection, options);
                UpdateOrAdd<CollectionLanguage>(context, Properties.Resources.collection_language, options);
                UpdateOrAdd<CollectionExercise>(context, Properties.Resources.collection_exercise, options);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }

            transaction.Commit();
        }

        private static void UpdateOrAdd<T>(CodeRunnerContext context, string data, JsonSerializerOptions options)
            where T : class
        {
            var list = JsonSerializer.Deserialize<List<T>>(data, options);
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

            if (context.Database.IsNpgsql())
            {
                UpdateSequence(context, table);
            }
        }

        /// <summary>
        /// Updates the id sequence in postgresql.
        /// </summary>
        /// <typeparam name="T">EntityType.</typeparam>
        /// <param name="context">Context.</param>
        /// <param name="table">TableSet.</param>
        private static void UpdateSequence<T>(this CodeRunnerContext context, DbSet<T> table)
            where T : class
        {
            string table_name = table.GetTableName<T>(context);

            // Parameterized query not supported by postgresql, but should not be a problem.
            context.Database.ExecuteSqlRaw($"SELECT setval(pg_get_serial_sequence('{table_name}', 'id'), coalesce(max(id), 0) + 1, false) FROM {table_name}");
            context.SaveChanges();
        }
    }
}
