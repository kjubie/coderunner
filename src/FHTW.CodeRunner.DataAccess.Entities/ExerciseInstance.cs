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
    [ExcludeFromCodeCoverage]
    [NotMapped]
    public class ExerciseInstance
    {
        /// <summary>
        /// Gets the id of the exercise.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the title of the exercise.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets the creation date of the exercise.
        /// </summary>
        public DateTime Created { get; init; }

        /// <summary>
        /// Gets the user that the created/owns the exercise.
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// Gets the written language of the exercise.
        /// </summary>
        public string WrittenLanguage { get; init; }

        /// <summary>
        /// Gets the programming language of the exercise.
        /// </summary>
        public string ProgrammingLanguage
        {
            get
            {
                if (this.Body != null)
                {
                    if (this.Body.FkProgrammingLanguage != null)
                    {
                        return this.Body.FkProgrammingLanguage.Name;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Gets the version of the exericse.
        /// </summary>
        public ExerciseVersion Version { get; init; }

        /// <summary>
        /// Gets the header of the exercise.
        /// </summary>
        public ExerciseHeader Header { get; init; }

        /// <summary>
        /// Gets the body of the exercise.
        /// </summary>
        public ExerciseBody Body { get; init; }

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
        /// Gets a collection of tags.
        /// </summary>
        public ICollection<Tag> TagList { get; init; }

        /// <summary>
        /// Gets a value indicating the state of the exercise.
        /// </summary>
        public ValidState ValidState
        {
            get
            {
                if (this.Version != null)
                {
                    return this.Version.ValidState;
                }
                else
                {
                    return ValidState.NotValid;
                }
            }
        }
    }
}
