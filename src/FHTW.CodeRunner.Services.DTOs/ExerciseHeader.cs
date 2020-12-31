// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseHeader
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// Gets or Sets the template parameter for the exercise.
        /// </summary>
        [DataMember(Name = "templateParam")]
        public string TemplateParam { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or Sets a value indicatíng whether the template parameter namespace can be omitted.
        /// </summary>
        [DataMember(Name = "templateParamLiftFlag")]
        public bool TemplateParamLiftFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether twig should be used for every field.
        /// </summary>
        [DataMember(Name = "twigAllFlag")]
        public bool TwigAllFlag { get; set; }
    }
}
