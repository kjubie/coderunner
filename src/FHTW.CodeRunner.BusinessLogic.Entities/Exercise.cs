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
        private User user;

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
        /// Gets or sets the Foreign Key for the user.
        /// </summary>
        public int FkUserId { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User FkUser
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;

                if (value != null)
                {
                    this.FkUserId = value.Id;
                }
            }
        }

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
