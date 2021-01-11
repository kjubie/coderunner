// <copyright file="ExerciseCreatePreparation.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes necesary data for the frontend when creating an exercise.
    /// </summary>
    public class ExerciseCreatePreparation
    {
        /// <summary>
        /// Gets or sets all available programming languages.
        /// </summary>
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        /// <summary>
        /// Gets or sets all available written languages.
        /// </summary>
        public List<WrittenLanguage> WrittenLanguages { get; set; }

        /// <summary>
        /// Gets or sets all available question types.
        /// </summary>
        public List<QuestionType> QuestionTypes { get; set; }

        /// <summary>
        /// Gets or sets all available tags.
        /// </summary>
        public List<Tag> Tags { get; set; }
    }
}
