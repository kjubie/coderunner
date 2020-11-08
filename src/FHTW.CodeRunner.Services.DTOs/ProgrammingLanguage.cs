// <copyright file="ProgrammingLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.ExerciseBody = new HashSet<ExerciseBody>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "collectionExerciseList")]
        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        [DataMember(Name = "exerciseBodyList")]
        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
