// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class ExerciseHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseHeader"/> class.
        /// </summary>
        public ExerciseHeader()
        {
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "fullTitle")]
        public string FullTitle { get; set; }

        [DataMember(Name = "shortTitle")]
        public string ShortTitle { get; set; }

        [DataMember(Name = "introduction")]
        public string Introduction { get; set; }
    }
}
