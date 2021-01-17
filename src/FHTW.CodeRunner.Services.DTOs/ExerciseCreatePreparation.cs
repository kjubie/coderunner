// <copyright file="ExerciseCreatePreparation.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes necesary data for the frontend when creating an exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseCreatePreparation
    {
        /// <summary>
        /// Gets or sets all available programming languages.
        /// </summary>
        [DataMember(Name = "programmingLanguageList")]
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        /// <summary>
        /// Gets or sets all available written languages.
        /// </summary>
        [DataMember(Name = "writtenLanguageList")]
        public List<WrittenLanguage> WrittenLanguages { get; set; }

        /// <summary>
        /// Gets or sets all available question types.
        /// </summary>
        [DataMember(Name = "questionTypeList")]
        public List<QuestionType> QuestionTypes { get; set; }

        /// <summary>
        /// Gets or sets all available tags.
        /// </summary>
        [DataMember(Name = "tagList")]
        public List<Tag> Tags { get; set; }
    }
}
