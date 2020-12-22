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
        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }
    }
}
