// <copyright file="ExerciseShort.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class ExerciseShort
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public User FkUser { get; set; }

        public List<Tag> Tags { get; set; }

        public List<WrittenLanguage> WrittenLanguages { get; set; }

        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
