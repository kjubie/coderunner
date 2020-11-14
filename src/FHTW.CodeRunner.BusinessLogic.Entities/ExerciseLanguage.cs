// <copyright file="ExerciseLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseLanguage
    {
        public ExerciseLanguage()
        {
            this.ExerciseBody = new HashSet<ExerciseBody>();
        }

        public int Id { get; set; }

        public int FkWrittenLanguageId { get; set; }

        public int FkExerciseVersionId { get; set; }

        public int FkExerciseHeaderId { get; set; }

        public ExerciseHeader FkExerciseHeader { get; set; }

        public ExerciseVersion FkExerciseVersion { get; set; }

        public WrittenLanguage FkWrittenLanguage { get; set; }

        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
