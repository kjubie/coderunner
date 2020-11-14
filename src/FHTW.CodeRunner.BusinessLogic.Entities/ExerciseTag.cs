// <copyright file="ExerciseTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseTag
    {
        public int Id { get; set; }

        public Exercise FkExercise { get; set; }

        public Tag FkTag { get; set; }
    }
}
