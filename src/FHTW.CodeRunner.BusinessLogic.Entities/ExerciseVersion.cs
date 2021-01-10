// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public enum ValidState
    {
        [EnumMember(Value = "NotValid")]
        NotValid = 0,

        [EnumMember(Value = "Valid")]
        Valid = 1,

        [EnumMember(Value = "NotChecked")]
        NotChecked = 2,
    }

    [ExcludeFromCodeCoverage]
    public class ExerciseVersion
    {
        private User user;

        public int Id { get; set; }

        public int VersionNumber { get; set; }

        public int? CreatorRating { get; set; }

        public int? CreatorDifficulty { get; set; }

        public DateTime LastModified { get; set; }

        public ValidState ValidState { get; set; }

        /// <summary>
        /// Gets or sets the Foreign Key for the user.
        /// </summary>
        public int FkUserId { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User FkUser
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;

                if (value != null)
                {
                    this.FkUserId = value.Id;
                }
            }
        }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
