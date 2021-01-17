// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes the header of an exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseHeader
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the fullt title.
        /// </summary>
        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or sets the introduction.
        /// </summary>
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
