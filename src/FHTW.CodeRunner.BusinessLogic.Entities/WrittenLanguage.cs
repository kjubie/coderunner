// <copyright file="WrittenLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class WrittenLanguage
    {
        public WrittenLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
