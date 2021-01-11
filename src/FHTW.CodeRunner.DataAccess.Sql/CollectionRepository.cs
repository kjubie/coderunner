// <copyright file="CollectionRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// The implemenation of the ICollectionRepository interface.
    /// This repository manages the collections.
    /// </summary>
    public class CollectionRepository : ICollectionRepository
    {
        private readonly CodeRunnerContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CollectionRepository(CodeRunnerContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public ICollection<ExerciseInstance> GetExercisesInstances(int id, string language = null)
        {
            var collection = this.context.Collection
                .Include(c => c.CollectionExercise)
                    .ThenInclude(x => x.FkProgrammingLanguage)
                .Include(c => c.CollectionExercise)
                    .ThenInclude(x => x.FkWrittenLanguage)
                .SingleOrDefault(c => c.Id == id);

            var list = collection?.CollectionExercise?.ToList() ?? throw new DalException($"collection with id = {id} does not exist");

            var repo = new ExerciseRepository(this.context);

            var instances = language switch
            {
                null => from ce in list select repo.GetExerciseInstance(ce.FkExerciseId, ce.FkProgrammingLanguage.Name, ce.FkWrittenLanguage.Name, ce.VersionNumber),
                _ => from ce in list select repo.GetExerciseInstance(ce.FkExerciseId, ce.FkProgrammingLanguage.Name, language, ce.VersionNumber),
            };

            return instances?.ToList();
        }

        /// <inheritdoc/>
        public CollectionInstance GetCollectionInstance(int id, string language, bool use_set_language)
        {
            ICollection<ExerciseInstance> exercises = null;

            exercises = use_set_language switch
            {
                true => this.GetExercisesInstances(id),
                false => this.GetExercisesInstances(id, language),
            };

            var instance = this.context.Collection
                .Where(c => c.Id == id)
                .Select(c => new CollectionInstance
                {
                    Id = c.Id,
                    Title = c.Title,
                    Created = c.Created,
                    User = c.FkUser,
                    Header = c.CollectionLanguage
                        .Single(l => l.FkWrittenLanguage.Name == language),
                    Exercises = exercises,
                }).Single();

            return instance;
        }
    }
}
