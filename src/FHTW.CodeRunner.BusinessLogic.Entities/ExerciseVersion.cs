// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.BusinessLogic.Entities
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

        public int Id { get; set; }

        public int VersionNumber { get; set; }

        public int? CreatorRating { get; set; }

        public int? CreatorDifficulty { get; set; }

        public DateTime LastModified { get; set; }

        public ValidState ValidState { get; set; }

        public User FkUser { get; set; }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
