// <copyright file="Difficulty.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Difficulty
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int FkExerciseId { get; set; }

        public int FkUserId { get; set; }

        public Exercise FkExercise { get; set; }

        public Benutzer FkUser { get; set; }
    }
}
