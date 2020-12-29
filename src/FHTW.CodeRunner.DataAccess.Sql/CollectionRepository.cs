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

        public CollectionInstance GetCollectionInstance(int id)
        {
            var instances = this.GetExercisesInstances(id);
            return this.context.Collection
                .Select(c => new CollectionInstance
                {
                    Id = c.Id,
                    Title = c.Title,
                    Created = c.Created,
                    User = c.FkUser,
                    Header = c.CollectionLanguage.FirstOrDefault(),
                    Exercises = instances,
                }).FirstOrDefault(c => c.Id == id);
        }

        public ICollection<ExerciseInstance> GetExercisesInstances(int id)
        {
            var list = this.GetCollectionExercises(id).ToList();

            var repo = new ExerciseRepository(this.context);

            var instances = from ce in list select repo.GetExerciseInstance(ce.FkExerciseId, ce.FkProgrammingLanguage.Name, ce.FkWrittenLanguage.Name, ce.VersionNumber);

            return instances.ToList();
        }

        private ICollection<CollectionExercise> GetCollectionExercises(int id)
        {
            // TODO select collection language first ?, first or default here questionable. Collection in different language can have different exercises ?
            return this.context.Collection
                .Single(c => c.Id == id)
                    .CollectionLanguage
                    .FirstOrDefault()
                        .CollectionExercise;
        }
    }
}
