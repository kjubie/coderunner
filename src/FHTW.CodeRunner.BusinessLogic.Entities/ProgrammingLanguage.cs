// <copyright file="ProgrammingLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            this.CollectionExercise = new HashSet<CollectionExercise>();
            this.ExerciseBody = new HashSet<ExerciseBody>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
