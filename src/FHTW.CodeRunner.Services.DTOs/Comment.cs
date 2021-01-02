// <copyright file="Comment.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes a comment.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class Comment
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the exercise.
        /// </summary>
        [DataMember(Name = "exercise")]
        public Exercise FkExercise { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [DataMember(Name = "user")]
        public User FkUser { get; set; }
    }
}
