// <copyright file="WrittenLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class WrittenLanguage
    {
        public WrittenLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "collectionExerciseList")]
        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        [DataMember(Name = "exerciseLanguageList")]
        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
