// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Enum that describes the state of an exercise.
    /// </summary>
    public enum ValidState
    {
        /// <summary>
        /// Exercise is not valid.
        /// </summary>
        [EnumMember(Value = "NotValid")]
        NotValid = 0,

        /// <summary>
        /// Exercise is valid.
        /// </summary>
        [EnumMember(Value = "Valid")]
        Valid = 1,

        /// <summary>
        /// Exercise has not been checked yet.
        /// </summary>
        [EnumMember(Value = "NotChecked")]
        NotChecked = 2,
    }

    /// <summary>
    /// Entity that describes the version of an exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseVersion
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the version number.
        /// </summary>
        [DataMember(Name = "versionNumber")]
        public int VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the rating from the creator.
        /// </summary>
        [DataMember(Name = "creatorRating")]
        public int? CreatorRating { get; set; }

        /// <summary>
        /// Gets or sets the difficulty from the creator.
        /// </summary>
        [DataMember(Name = "creatorDifficulty")]
        public int? CreatorDifficulty { get; set; }

        /// <summary>
        /// Gets or sets the last date an exercise was modified.
        /// </summary>
        [DataMember(Name = "lastModified")]
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [DataMember(Name = "validState")]
        public ValidState ValidState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an exercise is temporary.
        /// </summary>
        [DataMember(Name = "temporaryFlag")]
        public bool TemporaryFlag { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        [DataMember(Name = "user")]
        public User FkUser { get; set; }

        /// <summary>
        /// Gets or sets multiple exercise languages.
        /// </summary>
        [DataMember(Name = "exerciseLanguageList")]
        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
