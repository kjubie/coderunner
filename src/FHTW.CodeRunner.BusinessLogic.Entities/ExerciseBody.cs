// <copyright file="ExerciseBody.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseBody
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Example { get; set; }

        public string Hint { get; set; }

        public ExerciseLanguage FkExerciseLanguage { get; set; }

        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        public TestSuite FkTestSuite { get; set; }
    }
}
