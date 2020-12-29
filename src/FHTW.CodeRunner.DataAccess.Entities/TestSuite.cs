// <copyright file="TestSuite.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// The TestSuite entity.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("test_suite")]
    public partial class TestSuite : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestSuite"/> class.
        /// </summary>
        public TestSuite()
        {
            this.ExerciseBody = new HashSet<ExerciseBody>();
            this.TestCase = new HashSet<TestCase>();
        }

        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the question type.
        /// </summary>
        [Column("fk_question_type_id")]
        [StringLength(255)]
        public int? FkQuestionTypeId { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the from the template generated program should be displayed.
        /// </summary>
        [Column("template_debug_flag")]
        public bool TemplateDebugFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the test cases should be tested on save.
        /// Not part of FHTW-CodeRunner, but of moodle.
        /// </summary>
        [Column("test_on_save_flag")]
        public bool TestOnSaveFlag { get; set; }

        /// <summary>
        /// Gets or Sets the global extra that is available in each test case.
        /// </summary>
        [Column("global_extra_param")]
        public string GlobalExtraParam { get; set; }

        /// <summary>
        /// Gets or Sets runtime data.
        /// </summary>
        [Column("runtime_data")]
        public string RuntimeData { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.Exercise"/>.
        /// </summary>
        [InverseProperty("FkTestSuite")]
        public virtual ICollection<ExerciseBody> ExerciseBody { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.TestCase"/>.
        /// </summary>
        [InverseProperty("FkTestSuite")]
        public virtual ICollection<TestCase> TestCase { get; set; }

        /// <summary>
        /// Gets or Sets the questiontype foreign property.
        /// </summary>
        [ForeignKey(nameof(FkQuestionTypeId))]
        public QuestionType FkQuestionType { get; set; }
    }
}
