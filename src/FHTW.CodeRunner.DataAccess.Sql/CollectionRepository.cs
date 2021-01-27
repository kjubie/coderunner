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
using NinjaNye.SearchExtensions;

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
                }).SingleOrDefault();

            return instance;
        }

        /// <inheritdoc/>
        public Collection CreateOrUpdate(Collection collection)
        {
            try
            {
                using var transaction = this.context.Database.BeginTransaction();

                // set ids of existing tags with no id.
                // this can happen if an exercise imported from moodle has the same tag, but of course no id.
                collection.CollectionTag.ToList().ForEach(ct =>
                {
                    if (ct.FkTag != null)
                    {
                        int? id = this.context.Tag.AsNoTracking().SingleOrDefault(t => t.Name == ct.FkTag.Name)?.Id;
                        if (id != null)
                        {
                            ct.FkTag.Id = (int)id;
                        }
                    }
                });

                // add everything new
                this.context.ChangeTracker.TrackGraph(collection, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Unchanged;
                    }
                    else
                    {
                        e.Entry.State = EntityState.Added;
                    }
                });

                this.context.SaveChanges();

                // update existing
                this.context.ChangeTracker.TrackGraph(collection, e =>
                {
                    if (e.Entry.IsKeySet)
                    {
                        e.Entry.State = EntityState.Modified;
                    }
                });

                // don't update other fields
                this.context.Entry(collection).Property(x => x.Created).IsModified = false;
                this.context.Entry(collection).Property(x => x.FkUserId).IsModified = false;
                this.context.Entry(collection).Reference(x => x.FkUser).IsModified = false;

                collection.CollectionLanguage.ToList().ForEach(cl =>
                {
                    this.context.Entry(cl).Reference(x => x.FkWrittenLanguage).IsModified = false;
                });

                collection.CollectionExercise.ToList().ForEach(ce =>
                {
                    this.context.Entry(ce).Reference(x => x.FkWrittenLanguage).IsModified = false;
                    this.context.Entry(ce).Reference(x => x.FkProgrammingLanguage).IsModified = false;
                    this.context.Entry(ce).Reference(x => x.FkExercise).IsModified = false;
                });

                collection.CollectionTag.ToList().ForEach(ct =>
                {
                    this.context.Entry(ct).Reference(x => x.FkTag).IsModified = false;
                });

                this.context.SaveChanges();

                transaction.Commit();
            }
            catch (Exception e) when (e is DbUpdateException || e is DbUpdateConcurrencyException)
            {
                throw new DalException("Updating collection failed", e);
            }
            catch (Exception e)
            {
                throw new DalException("Unexpected error while updating collection", e);
            }

            return collection;
        }

        /// <inheritdoc/>
        public Collection GetById(int id)
        {
            return this.context.Collection
                .AsNoTracking()
                .Include(c => c.CollectionLanguage)
                    .ThenInclude(cl => cl.FkWrittenLanguage)
                .Include(c => c.CollectionTag)
                    .ThenInclude(ct => ct.FkTag)
                .Include(c => c.CollectionExercise)
                    .ThenInclude(ce => ce.FkProgrammingLanguage)
                .Include(c => c.CollectionExercise)
                    .ThenInclude(ce => ce.FkWrittenLanguage)
                .SingleOrDefault(c => c.Id == id);
        }

        /// <inheritdoc/>
        public List<MinimalCollection> GetMinimalCollections()
        {
            return this.context.Collection.AsNoTracking()
                .Select(MinimalCollection.FromCollection)
                .ToList();
        }

        /// <inheritdoc/>
        public List<MinimalCollection> SearchAndFilter(string search_term, string written_language)
        {
            HashSet<int> ids = this.context.CollectionLanguage
                .Search(
                        c => c.FullTitle.ToLower(),
                        c => c.ShortTitle.ToLower(),
                        c => c.Introduction.ToLower(),
                        c => c.FkCollection.Title.ToLower(),
                        c => c.FkCollection.FkUser.Name.ToLower())
                    .Containing(search_term.ToLower())
                .Select(c => c.FkCollectionId)
                .ToHashSet();

            HashSet<int> ids_from_tag_search = this.context.CollectionTag
                .Search(ct => ct.FkTag.Name.ToLower())
                    .Containing(search_term.ToLower())
                .Select(c => c.FkCollectionId)
                .ToHashSet();

            if (written_language != string.Empty)
            {
                HashSet<int> ids_from_filters = this.context.CollectionLanguage
                    .Search(cl => cl.FkWrittenLanguage.Name)
                        .Containing(written_language)
                    .Select(c => c.FkCollectionId)
                    .ToHashSet();

                ids.IntersectWith(ids_from_filters);
            }

            List<MinimalCollection> result;

            if (ids.Count > 0)
            {
                result = this.context.Collection
                    .Where(c => ids.Contains(c.Id))
                    .Select(MinimalCollection.FromCollection)
                    .ToList();
            }
            else
            {
                result = new List<MinimalCollection>();
            }

            return result;
        }
    }
}
