// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    public enum ValidState
    {
        [EnumMember(Value = "NotValid")]
        NotValid = 0,

        [EnumMember(Value = "Valid")]
        Valid = 1,

        [EnumMember(Value = "NotChecked")]
        NotChecked = 2,
    }

    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseVersion"/> class.
        /// </summary>
        public ExerciseVersion()
        {
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "versionNumber")]
        public int VersionNumber { get; set; }

        [DataMember(Name = "creatorRating")]
        public int? CreatorRating { get; set; }

        [DataMember(Name = "creatorDifficulty")]
        public int? CreatorDifficulty { get; set; }

        [DataMember(Name = "lastModified")]
        public DateTime LastModified { get; set; }

        [DataMember(Name = "validState")]
        public ValidState ValidState { get; set; }

        [DataMember(Name = "user")]
        public User FkUser { get; set; }

        [DataMember(Name = "exerciseLanguageList")]
        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
