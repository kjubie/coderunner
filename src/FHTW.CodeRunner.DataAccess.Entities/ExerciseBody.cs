// <copyright file="ExerciseBody.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// The EcerciseBody entity contains exercise fields that are both programminglanguage
    /// and written language specific.
    /// </summary>
    [Table("exercise_body")]
    public partial class ExerciseBody : IEntity
    {
        /// <summary>
        /// The minimum value of the allowed_files property.
        /// </summary>
        public const int MinAllowedFilesVal = 0;

        /// <summary>
        /// The maximum value of the allowed_files property.
        /// </summary>
        public const int MaxAllowedFilesVal = 4;

        /// <summary>
        /// The minimum value of the files_required property.
        /// </summary>
        public const int MinRequiredFilesVal = 0;

        /// <summary>
        /// The maximum value of the files_required.
        /// </summary>
        public const int MaxRequiredFilesVal = 3;

        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the programming language foreign key id.
        /// (<see cref="FHTW.CodeRunner.DataAccess.Entities.ProgrammingLanguage"/>).
        /// </summary>
        [Column("fk_programming_language_id")]
        public int FkProgrammingLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets the question description specific to a programming language.
        /// </summary>
        [Column("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the hint for the exercise.
        /// </summary>
        [Column("hint")]
        public string Hint { get; set; }

        /// <summary>
        /// Gets or Sets the exercise language foreign key id.
        /// (<see cref="FHTW.CodeRunner.DataAccess.Entities.ExerciseLanguage"/>).
        /// </summary>
        [Column("fk_exercise_language_id")]
        public int FkExerciseLanguageId { get; set; }

        /// <summary>
        /// Gets or Sets the testsuite foreign key id.
        /// (<see cref="FHTW.CodeRunner.DataAccess.Entities.TestSuite"/>).
        /// </summary>
        [Column("fk_test_suite_id")]
        public int FkTestSuiteId { get; set; }

        /// <summary>
        /// Gets or Sets the number of lines in the students answer field.
        /// </summary>
        [Column("field_lines")]
        public int FieldLines { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether to require all tests to be successfull in order get any grading.
        /// </summary>
        [Column("grading_flag")]
        public bool GradingFlag { get; set; }

        /// <summary>
        /// Gets or Sets the system that sets how points are substracted in case of a wrong answer.
        /// Example(without ""): "10, 20, ...".
        /// </summary>
        [Column("substract_system")]
        public string SubtractSystem { get; set; }

        /// <summary>
        /// Gets or Sets the number of attainable points.
        /// </summary>
        [Column("optainable_points")]
        public int OptainablePoints { get; set; }

        /// <summary>
        /// Gets or Sets the ID Number that identifies groups in moodle.
        /// </summary>
        [Column("id_num")]
        public int IdNum { get; set; }

        /// <summary>
        /// Gets or Sets the solution to the exersice.
        /// </summary>
        [Column("solution")]
        public string Solution { get; set; }

        /// <summary>
        /// Gets or Sets the prefill for the solution field.
        /// </summary>
        [Column("prefill")]
        public string Prefill { get; set; }

        /// <summary>
        /// Gets or Sets the general feedback for the exercise.
        /// </summary>
        [Column("feedback")]
        public string Feedback { get; set; }

        /// <summary>
        /// Gets or Sets the mode of the allowed attachments field.
        /// Value Constraints {0,1,2,3,4} in <see cref="FHTW.CodeRunner.DataAccess.Sql.CodeRunnerContext"/>.
        /// </summary>
        [Column("allow_files")]
        public int AllowFiles { get; set; }

        /// <summary>
        /// Gets or Sets the mode of the attachments required field.
        /// Value Constraints {0,1,2,3} in <see cref="FHTW.CodeRunner.DataAccess.Sql.CodeRunnerContext"/>.
        /// </summary>
        [Column("files_required")]
        public int FilesRequired { get; set; }

        /// <summary>
        /// Gets or Sets the regex for the students attachments.
        /// </summary>
        [Column("files_regex")]
        [StringLength(255)]
        public string FilesRegex { get; set; }

        /// <summary>
        /// Gets or Sets the description to the attachments.
        /// </summary>
        [Column("files_description")]
        public string FilesDescription { get; set; }

        /// <summary>
        /// Gets or Sets the maximum attachment size in bytes.
        /// </summary>
        [Column("files_size")]
        public int FilesSize { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.ExerciseLanguage"/>.
        /// </summary>
        [ForeignKey(nameof(FkExerciseLanguageId))]
        [InverseProperty(nameof(ExerciseLanguage.ExerciseBody))]
        public virtual ExerciseLanguage FkExerciseLanguage { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.ProgrammingLanguage"/>.
        /// </summary>
        [ForeignKey(nameof(FkProgrammingLanguageId))]
        [InverseProperty(nameof(ProgrammingLanguage.ExerciseBody))]
        public virtual ProgrammingLanguage FkProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.TestSuite"/>.
        /// </summary>
        [ForeignKey(nameof(FkTestSuiteId))]
        [InverseProperty(nameof(TestSuite.ExerciseBody))]
        public virtual TestSuite FkTestSuite { get; set; }
    }
}
