// <copyright file="TestCase.cs" company="FHTW CodeRunner">
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
    /// The TestCase entity.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Table("test_case")]
    public partial class TestCase : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets at what order the testcase should be called (optional).
        /// </summary>
        [Column("order_used")]
        public int? OrderUsed { get; set; }

        /// <summary>
        /// Gets or Sets the code for the test.
        /// </summary>
        [Column("test_code")]
        public string TestCode { get; set; }

        /// <summary>
        /// Gets or Sets the default input of the test.
        /// </summary>
        [Column("standard_input")]
        public string StandardInput { get; set; }

        /// <summary>
        /// Gets or Sets the expected ouput for the test.
        /// </summary>
        [Column("expected_output")]
        public string ExpectedOutput { get; set; }

        /// <summary>
        /// Gets or Sets additional data used in the testcase.
        /// </summary>
        [Column("additional_data")]
        public string AdditionalData { get; set; }

        /// <summary>
        /// Gets or Sets the attainable points of the test.
        /// </summary>
        [Column("points")]
        public int? Points { get; set; } // TODO null ?

        /// <summary>
        /// Gets or Sets the foreign testsuite id.
        /// </summary>
        [Column("fk_test_suite_id")]
        public int FkTestSuiteId { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the test should be used as an example.
        /// </summary>
        [Column("use_as_example_flag")]
        public bool UseAsExampleFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the following test should be hidden if this one fails.
        /// </summary>
        [Column("hide_on_fail_flag")]
        public bool HideOnFailFlag { get; set; }

        /// <summary>
        /// Gets or Sets in which case this test case should be hidden.
        /// Values: {SHOW, HIDE, HIDE_IF_FAIL, HIDE_IF_SUCCEED}.
        /// </summary>
        [Column("display_type")]
        [StringLength(16)]
        public string DisplayType { get; set; }

        /// <summary>
        /// Gets or Sets the inverse property of <see cref="Entities.TestSuite"/>.
        /// </summary>
        [ForeignKey(nameof(FkTestSuiteId))]
        [InverseProperty(nameof(TestSuite.TestCase))]
        public virtual TestSuite FkTestSuite { get; set; }
    }
}
