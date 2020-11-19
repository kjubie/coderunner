// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseVersion"/> class.
        /// </summary>
        public ExerciseVersion()
        {
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        public int Id { get; set; }

        public int VersionNumber { get; set; }

        public int? CreatorRating { get; set; }

        public int? CreatorDifficulty { get; set; }

        public DateTime LastModified { get; set; }

        public User FkUser { get; set; }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
