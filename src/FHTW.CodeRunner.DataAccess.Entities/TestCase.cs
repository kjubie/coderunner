// <copyright file="TestCase.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("test_case")]
    public partial class TestCase
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_used")]
        public int? OrderUsed { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("standard_input")]
        public string StandardInput { get; set; }

        [Column("expected_output")]
        public string ExpectedOutput { get; set; }

        [Column("additional_data")]
        public string AdditionalData { get; set; }

        [Column("points")]
        public int? Points { get; set; }

        [Column("fk_test_suite_id")]
        public int FkTestSuiteId { get; set; }

        [ForeignKey(nameof(FkTestSuiteId))]
        [InverseProperty(nameof(TestSuite.TestCase))]
        public virtual TestSuite FkTestSuite { get; set; }
    }
}
