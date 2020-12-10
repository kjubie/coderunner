// <copyright file="ExerciseBody.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class ExerciseBody
    {
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
        public int OptainablePoints { get; set; }

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
        /// Value Constraints {0,1,2,3,4} in <see cref="FHTW.CodeRunner.DataAccess.Sql.CodeRunnerContext"/>.
        /// </summary>
        public int AllowFiles { get; set; }

        /// <summary>
        /// Gets or Sets the mode of the attachments required field.
        /// Value Constraints {0,1,2,3} in <see cref="FHTW.CodeRunner.DataAccess.Sql.CodeRunnerContext"/>.
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

        public ExerciseLanguage FkExerciseLanguage { get; set; }

        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        public TestSuite FkTestSuite { get; set; }
    }
}
