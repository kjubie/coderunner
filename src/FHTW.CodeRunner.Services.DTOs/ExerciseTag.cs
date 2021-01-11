// <copyright file="ExerciseTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that connects a tag to an exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseTag
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        [DataMember(Name = "tag")]
        public Tag FkTag { get; set; }
    }
}
