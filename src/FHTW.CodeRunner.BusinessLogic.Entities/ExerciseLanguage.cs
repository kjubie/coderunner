// <copyright file="ExerciseLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entit that describes the written language for an exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseLanguage
    {
        private WrittenLanguage writtenLanguage;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the exercise header.
        /// </summary>
        public ExerciseHeader FkExerciseHeader { get; set; }

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

        /// <summary>
        /// Gets or sets multiple exercise bodies.
        /// </summary>
        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
