// <copyright file="MinimalExercise.cs" company="FHTW CodeRunner">
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
    /// A minimal version of the exercise entity containing only the metadata.
    /// This Entity is not mapped and therefore not managed by the ef core.
    /// All modifications made to the entities will not be persistet.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [NotMapped]
    public class MinimalExercise
    {
        /// <summary>
        /// Gets the projection for MinimalExercise from Exercise.
        /// </summary>
        public static Expression<Func<Exercise, MinimalExercise>> Projection
        {
            get
            {
                return m => new MinimalExercise()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Created = m.Created,
                    User = m.FkUser,
                    TagList = m.ExerciseTag
                            .Select(et => new Tag()
                            {
                                Id = et.FkTagId,
                                Name = et.FkTag.Name,
                            })
                            .ToList(),
                    WrittenLanguageList = m.ExerciseVersion
                            .Where(v => v.VersionNumber == m.ExerciseVersion.Max(vn => vn.VersionNumber))
                            .FirstOrDefault().ExerciseLanguage
                            .Select(el => new WrittenLanguage()
                            {
                                Id = el.FkWrittenLanguageId,
                                Name = el.FkWrittenLanguage.Name,
                            })
                            .ToList(),
                    ProgrammingLanguageList = m.ExerciseVersion
                            .Where(v => v.VersionNumber == m.ExerciseVersion.Max(vn => vn.VersionNumber))
                            .FirstOrDefault().ExerciseLanguage
                            .SelectMany(el => el.ExerciseBody.Select(eb => new ProgrammingLanguage()
                            {
                                Id = eb.FkProgrammingLanguageId,
                                Name = eb.FkProgrammingLanguage.Name,
                            }))
                            .ToHashSet(new ProgrammingLanguageComparator())
                            .ToList(),
                    VersionList = m.ExerciseVersion
                            .Select(v => v.VersionNumber)
                            .ToList(),
                };
            }
        }

        /// <summary>
        /// Gets the id of the exercise.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the title of the exercise.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets the creation date of the exercise.
        /// </summary>
        public DateTime Created { get; init; }

        /// <summary>
        /// Gets the user that the created/owns the exercise.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// Gets a collection of tags.
        /// </summary>
        public ICollection<Tag> TagList { get; init; }

        /// <summary>
        /// Gets a collection of written languages, in which the exercise is availbale in.
        /// </summary>
        public ICollection<WrittenLanguage> WrittenLanguageList { get; init; }

        /// <summary>
        /// Gets a collection of programming languages, in which the exercise is availbale in.
        /// </summary>
        public ICollection<ProgrammingLanguage> ProgrammingLanguageList { get; init; }

        /// <summary>
        /// Gets a collection of versions, in which the exercise is availbale in.
        /// </summary>
        public ICollection<int> VersionList { get; init; }
    }
}
