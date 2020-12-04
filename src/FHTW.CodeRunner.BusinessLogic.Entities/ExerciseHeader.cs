// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseHeader"/> class.
        /// </summary>
        public ExerciseHeader()
        {
        }

        public string FullTitle { get; set; }

        public string Introduction { get; set; }
    }
}
