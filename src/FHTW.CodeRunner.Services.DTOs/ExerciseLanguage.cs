// <copyright file="ExerciseLanguage.cs" company="FHTW CodeRunner">
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
    public class ExerciseLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseLanguage"/> class.
        /// </summary>
        public ExerciseLanguage()
        {
            this.ExerciseBody = new HashSet<ExerciseBody>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "exerciseHeader")]
        public ExerciseHeader FkExerciseHeader { get; set; }

        [DataMember(Name = "writtenLanguage")]
        public WrittenLanguage FkWrittenLanguage { get; set; }

        [DataMember(Name = "exerciseBody")]
        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
