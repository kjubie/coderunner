// <copyright file="ExerciseLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class ExerciseLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseLanguage"/> class.
        /// </summary>
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
