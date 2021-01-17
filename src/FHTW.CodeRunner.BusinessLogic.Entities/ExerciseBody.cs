// <copyright file="ExerciseBody.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the body for an exercise.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseBody
    {
        private ProgrammingLanguage programmingLanguage;

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the question description specific to a programming language.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the hint for the exercise.
        /// </summary>
        public string Hint { get; set; }

        /// <summary>
        /// Gets or Sets the number of lines in the students answer field.
        /// </summary>
        public int FieldLines { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether to require all tests to be successfull in order get any grading.
        /// </summary>
        public bool GradingFlag { get; set; }

        /// <summary>
        /// Gets or Sets the system that sets how points are substracted in case of a wrong answer.
        /// Example(without ""): "10, 20, ...".
        /// </summary>
        public string SubtractSystem { get; set; }

        /// <summary>
        /// Gets or Sets the number of attainable points.
        /// </summary>
        public int ObtainablePoints { get; set; }

        /// <summary>
        /// Gets or Sets the ID Number that identifies groups in moodle.
        /// </summary>
        public int IdNum { get; set; }

        /// <summary>
        /// Gets or Sets the solution to the exersice.
        /// </summary>
        public string Solution { get; set; }

        /// <summary>
        /// Gets or Sets the prefill for the solution field.
        /// </summary>
        public string Prefill { get; set; }

        /// <summary>
        /// Gets or Sets the general feedback for the exercise.
        /// </summary>
        public string Feedback { get; set; }

        /// <summary>
        /// Gets or Sets the mode of the allowed attachments field.
        /// </summary>
        public int AllowFiles { get; set; }

        /// <summary>
        /// Gets or Sets the mode of the attachments required field.
        /// </summary>
        public int FilesRequired { get; set; }

        /// <summary>
        /// Gets or Sets the regex for the students attachments.
        /// </summary>
        public string FilesRegex { get; set; }

        /// <summary>
        /// Gets or Sets the description to the attachments.
        /// </summary>
        public string FilesDescription { get; set; }

        /// <summary>
        /// Gets or Sets the maximum attachment size in bytes.
        /// </summary>
        public int FilesSize { get; set; }

        /// <summary>
        /// Gets or sets the language for the exercise.
        /// </summary>
        public ExerciseLanguage FkExerciseLanguage { get; set; }

        /// <summary>
        /// Gets or sets the Foreign Key for the programming language.
        /// </summary>
        public int FkProgrammingLanguageId { get; set; }

        /// <summary>
        /// Gets or sets the programming language.
        /// </summary>
        public ProgrammingLanguage FkProgrammingLanguage
        {
            get
            {
                return this.programmingLanguage;
            }

            set
            {
                this.programmingLanguage = value;

                if (value != null)
                {
                    this.FkProgrammingLanguageId = value.Id;
                }
            }
        }

        /// <summary>
        /// Gets or sets the test suite for the exercise.
        /// </summary>
        public TestSuite FkTestSuite { get; set; }
    }
}
