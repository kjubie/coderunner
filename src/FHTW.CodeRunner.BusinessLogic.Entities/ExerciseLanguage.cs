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
        private WrittenLanguage writtenLanguage;

        public int Id { get; set; }

        public int FkExerciseVersionId { get; set; }

        public int FkExerciseHeaderId { get; set; }

        public ExerciseHeader FkExerciseHeader { get; set; }

        public ExerciseVersion FkExerciseVersion { get; set; }

        /// <summary>
        /// Gets or sets the Foreign Key for the written language.
        /// </summary>
        public int FkWrittenLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        public WrittenLanguage FkWrittenLanguage
        {
            get
            {
                return this.writtenLanguage;
            }

            set
            {
                this.writtenLanguage = value;

                if (value != null)
                {
                    this.FkWrittenLanguageId = value.Id;
                }
            }
        }

        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
