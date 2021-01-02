// <copyright file="Comment.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes a comment.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Comment
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the exercise.
        /// </summary>
        public Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User FkUser { get; set; }
    }
}
