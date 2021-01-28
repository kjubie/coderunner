// <copyright file="MinimalCollection.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// A view version of the collection entity.
    /// It contains anything necessary to display the collection.
    /// This Entity is not mapped and therefore not managed by the ef core.
    /// All modifications made to the entities will not be persistet.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [NotMapped]
    public class MinimalCollectionExercise
    {
        /// <summary>
        /// Gets projection from Collection to MinimalCollectionExercise.
        /// </summary>
        public static Expression<Func<CollectionExercise, MinimalCollectionExercise>> FromCollectionExercise
        {
            get
            {
                return c => new MinimalCollectionExercise()
                {
                    ExerciseId = c.FkExerciseId,
                    Title = c.FkExercise.Title,
                    Created = c.FkExercise.Created,
                    User = c.FkExercise.FkUser,
                    WrittenLanguage = c.FkWrittenLanguage.Name,
                    ProgrammingLanguage = c.FkProgrammingLanguage.Name,
                    Version = c.VersionNumber,
                };
            }
        }

        /// <summary>
        /// Gets the id of the exercise.
        /// </summary>
        public int ExerciseId { get; init; }

        /// <summary>
        /// Gets the title of the exercise.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets the creation date of the collection.
        /// </summary>
        public DateTime Created { get; init; }

        /// <summary>
        /// Gets the user that created the collection.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// Gets the selected written language.
        /// </summary>
        public string WrittenLanguage { get; init; }

        /// <summary>
        /// Gets the selected programming language.
        /// </summary>
        public string ProgrammingLanguage { get; init; }

        /// <summary>
        /// Gets the selected version.
        /// </summary>
        public int Version { get; init; }
    }
}
