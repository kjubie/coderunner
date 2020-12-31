// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class ExerciseHeader
    {
        public int Id { get; set; }

        public string FullTitle { get; set; }

        public string Introduction { get; set; }

        /// <summary>
        /// Gets or Sets the template parameter for the exercise.
        /// </summary>
        public string TemplateParam { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets a value indicatíng whether the template parameter namespace can be omitted.
        /// </summary>
        public bool TemplateParamLiftFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether twig should be used for every field.
        /// </summary>
        public bool TwigAllFlag { get; set; }
    }
}
