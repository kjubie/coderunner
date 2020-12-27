// <copyright file="MinimalExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// A minimal version of the exercise entity containing only the metadata.
    /// This Entity is not mapped and therefore not managed by the ef core.
    /// All modifications made to the entities will not be persistet.
    /// </summary>
    [NotMapped]
    public class MinimalExercise
    {
        /// <summary>
        /// Gets or Sets the id of the exercise.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the title of the exercise.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the creation date of the exercise.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets the user that the created/owns the exercise.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or Sets a collection of tags.
        /// </summary>
        public ICollection<Tag> TagList { get; set; }

        /// <summary>
        /// Gets or Sets a collection of written languages, in which the exercise is availbale in.
        /// </summary>
        public ICollection<WrittenLanguage> WrittenLanguageList { get; set; }

        /// <summary>
        /// Gets or Sets a collection of programming languages, in which the exercise is availbale in.
        /// </summary>
        public ICollection<ProgrammingLanguage> ProgrammingLanguageList { get; set; }
    }
}
