// <copyright file="ExerciseShort.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Gets or sets a minmal version of an exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseShort
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [DataMember(Name = "user")]
        public User FkUser { get; set; }

        /// <summary>
        /// Gets or sets multiple tags.
        /// </summary>
        [DataMember(Name = "tagList")]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets multiple written languages.
        /// </summary>
        [DataMember(Name = "writtenLanguageList")]
        public List<WrittenLanguage> WrittenLanguages { get; set; }

        /// <summary>
        /// Gets or sets multiple programming languages.
        /// </summary>
        [DataMember(Name = "programmingLanguageList")]
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        /// <summary>
        /// Gets or sets a collection of versions, in which the exercise is availbale in.
        /// </summary>
        [DataMember(Name = "versionList")]
        public ICollection<int> VersionList { get; set; }
    }
}
