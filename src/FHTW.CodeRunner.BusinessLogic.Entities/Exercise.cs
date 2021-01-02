// <copyright file="Exercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Exercise
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Exercise"/> class.
        /// </summary>
        public Exercise()
        {
            this.Comment = new HashSet<Comment>();
            this.Difficulty = new HashSet<Difficulty>();
            this.ExerciseTag = new HashSet<ExerciseTag>();
            this.ExerciseVersion = new HashSet<ExerciseVersion>();
            this.Rating = new HashSet<Rating>();
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User FkUser { get; set; }

        /// <summary>
        /// Gets or sets multiple comments.
        /// </summary>
        public ICollection<Comment> Comment { get; set; }

        /// <summary>
        /// Gets or sets multiple difficulties.
        /// </summary>
        public ICollection<Difficulty> Difficulty { get; set; }

        /// <summary>
        /// Gets or sets multiple tags.
        /// </summary>
        public ICollection<ExerciseTag> ExerciseTag { get; set; }

        /// <summary>
        /// Gets or sets multiple versions.
        /// </summary>
        public ICollection<ExerciseVersion> ExerciseVersion { get; set; }

        /// <summary>
        /// Gets or sets multiple ratings.
        /// </summary>
        public ICollection<Rating> Rating { get; set; }
    }
}
