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
        }
    }
}
