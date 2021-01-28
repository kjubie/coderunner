// <copyright file="ExerciseVersion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Enum that describes the state of an exercise.
    /// </summary>
    public enum ValidState
    {
        /// <summary>
        /// Exercise is not valid.
        /// </summary>
        [EnumMember(Value = "NotValid")]
        NotValid = 0,

        /// <summary>
        /// Exercise is valid.
        /// </summary>
        [EnumMember(Value = "Valid")]
        Valid = 1,

        /// <summary>
        /// Exercise has not been checked yet.
        /// </summary>
        [EnumMember(Value = "NotChecked")]
        NotChecked = 2,
    }

    /// <summary>
    /// Entity that describes the version of an exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseVersion
    {
        private User user;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the version number.
        /// </summary>
        public int VersionNumber { get; set; }

        /// <summary>
        /// Gets or sets the rating from the creator.
        /// </summary>
        public int? CreatorRating { get; set; }

        /// <summary>
        /// Gets or sets the difficulty from the creator.
        /// </summary>
        public int? CreatorDifficulty { get; set; }

        /// <summary>
        /// Gets or sets the last date an exercise was modified.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public ValidState ValidState { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an exercise is temporary.
        /// </summary>
        public bool TemporaryFlag { get; set; }

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

        /// <summary>
        /// Gets or sets multiple exercise languages.
        /// </summary>
        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
