// <copyright file="ExerciseInstance.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// A single exercise instance.
    /// Normaly an exercise can exist in many different written languages, versions or programming languages.
    /// An exercise instance however, only has one written language, version and programming language.
    /// This Entity is not mapped and therefore not managed by the ef core.
    /// All modifications made to the entities will not be persistet.
    /// </summary>
    [NotMapped]
    public class ExerciseInstance
    {
        /// <summary>
        /// Gets or Sets the id of the exercise.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the title of the exercise.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the creation date of the exercise.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets the user that the created/owns the exercise.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or Sets the written language of the exercise.
        /// </summary>
        public WrittenLanguage WrittenLanguage { get; set; }

        /// <summary>
        /// Gets the programming language of the exercise.
        /// </summary>
        public ProgrammingLanguage ProgrammingLanguage
        {
            get
            {
                if (this.Body != null)
                {
                    return this.Body.FkProgrammingLanguage;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets or Sets the version of the exericse.
        /// </summary>
        public ExerciseVersion Version { get; set; }

        /// <summary>
        /// Gets or Sets the header of the exercise.
        /// </summary>
        public ExerciseHeader Header { get; set; }

        /// <summary>
        /// Gets or Sets the body of the exercise.
        /// </summary>
        public ExerciseBody Body { get; set; }

        /// <summary>
        /// Gets the test suite.
        /// </summary>
        public TestSuite TestSuite
        {
            get
            {
                if (this.Body != null)
                {
                    return this.Body.FkTestSuite;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the exercise is valid.
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (this.Version != null)
                {
                    return this.Version.ValidFlag;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
