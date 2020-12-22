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
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseCreatePreparation
    {
        [DataMember(Name = "programmingLanguageList")]
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        [DataMember(Name = "writtenLanguageList")]
        public List<WrittenLanguage> WrittenLanguages { get; set; }

        [DataMember(Name = "questionTypeList")]
        public List<QuestionType> QuestionTypes { get; set; }
    }
}
