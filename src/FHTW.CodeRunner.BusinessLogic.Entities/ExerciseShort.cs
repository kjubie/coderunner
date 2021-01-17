// <copyright file="ExerciseShort.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Gets or sets a minmal version of an exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseShort
    {
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
        /// Gets or sets multiple tags.
        /// </summary>
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets multiple written languages.
        /// </summary>
        public List<WrittenLanguage> WrittenLanguages { get; set; }

        /// <summary>
        /// Gets or sets multiple programming languages.
        /// </summary>
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        /// <summary>
        /// Gets or sets a collection of versions, in which the exercise is availbale in.
        /// </summary>
        public ICollection<int> VersionList { get; set; }
    }
}
