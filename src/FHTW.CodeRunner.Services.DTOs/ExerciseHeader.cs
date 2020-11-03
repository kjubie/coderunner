﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class ExerciseHeader
    {
        public ExerciseHeader()
        {
            ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        [DataMember(Name = "shortTitle")]
        public string ShortTitle { get; set; }

        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }

        [DataMember(Name = "exerciseLanguageList")]
        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}