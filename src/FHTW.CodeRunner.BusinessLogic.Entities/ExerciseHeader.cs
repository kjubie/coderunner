// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseHeader
    {
        public ExerciseHeader()
        {
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        public int Id { get; set; }

        public string FullTitle { get; set; }

        public string ShortTitle { get; set; }

        public string Introduction { get; set; }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
