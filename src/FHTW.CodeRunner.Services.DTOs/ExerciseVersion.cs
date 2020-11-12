﻿// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class ExerciseVersion
    {
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

        [DataMember(Name = "user")]
        public Benutzer FkUser { get; set; }

        [DataMember(Name = "exerciseLanguageList")]
        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
