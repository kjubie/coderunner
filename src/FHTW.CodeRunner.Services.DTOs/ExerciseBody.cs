// <copyright file="ExerciseBody.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes the body for an exercise.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseBody
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the question description specific to a programming language.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the hint for the exercise.
        /// </summary>
        [DataMember(Name = "hint")]
        public string Hint { get; set; }

        /// <summary>
        /// Gets or Sets the number of lines in the students answer field.
        /// </summary>
        [DataMember(Name = "fieldLines")]
        public int FieldLines { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether to require all tests to be successfull in order get any grading.
        /// </summary>
        [DataMember(Name = "gradingFlag")]
        public bool GradingFlag { get; set; }

        /// <summary>
        /// Gets or Sets the system that sets how points are substracted in case of a wrong answer.
        /// Example(without ""): "10, 20, ...".
        /// </summary>
        [DataMember(Name = "subtractSystem")]
        public string SubtractSystem { get; set; }

        /// <summary>
        /// Gets or Sets the number of attainable points.
        /// </summary>
        [DataMember(Name = "obtainablePoints")]
        public int ObtainablePoints { get; set; }

        /// <summary>
        /// Gets or Sets the ID Number that identifies groups in moodle.
        /// </summary>
        [DataMember(Name = "idNum")]
        public int IdNum { get; set; }

        /// <summary>
        /// Gets or Sets the solution to the exersice.
        /// </summary>
        [DataMember(Name = "solution")]
        public string Solution { get; set; }

        /// <summary>
        /// Gets or Sets the prefill for the solution field.
        /// </summary>
        [DataMember(Name = "prefill")]
        public string Prefill { get; set; }

        /// <summary>
        /// Gets or Sets the general feedback for the exercise.
        /// </summary>
        [DataMember(Name = "feedback")]
        public string Feedback { get; set; }

        /// <summary>
        /// Gets or Sets the mode of the allowed attachments field.
        /// </summary>
        [DataMember(Name = "allowFiles")]
        public int AllowFiles { get; set; }

        /// <summary>
        /// Gets or Sets the mode of the attachments required field.
        /// </summary>
        [DataMember(Name = "filesRequired")]
        public int FilesRequired { get; set; }

        /// <summary>
        /// Gets or Sets the regex for the students attachments.
        /// </summary>
        [DataMember(Name = "filesRegex")]
        public string FilesRegex { get; set; }

        /// <summary>
        /// Gets or Sets the description to the attachments.
        /// </summary>
        [DataMember(Name = "filesDescription")]
        public string FilesDescription { get; set; }

        /// <summary>
        /// Gets or Sets the maximum attachment size in bytes.
        /// </summary>
        [DataMember(Name = "filesSize")]
        public int FilesSize { get; set; }

        /// <summary>
        /// Gets or sets the language for the exercise.
        /// </summary>
        [DataMember(Name = "exerciseLanguage")]
        public ExerciseLanguage FkExerciseLanguage { get; set; }

        /// <summary>
        /// Gets or sets the programming language for the exercise.
        /// </summary>
        [DataMember(Name = "programmingLanguage")]
        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or sets the test suite for the exercise.
        /// </summary>
        [DataMember(Name = "testSuite")]
        public TestSuite FkTestSuite { get; set; }
    }
}
