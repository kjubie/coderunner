﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("test_suite")]
    public partial class TestSuite
    {
        public TestSuite()
        {
            ExerciseBody = new HashSet<ExerciseBody>();
            TestCase = new HashSet<TestCase>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("question_type")]
        [StringLength(255)]
        public string QuestionType { get; set; }
        [Column("prefill")]
        public string Prefill { get; set; }
        [Column("solution")]
        public string Solution { get; set; }
        [Column("complexity")]
        public int? Complexity { get; set; }

        [InverseProperty("FkTestSuite")]
        public virtual ICollection<ExerciseBody> ExerciseBody { get; set; }
        [InverseProperty("FkTestSuite")]
        public virtual ICollection<TestCase> TestCase { get; set; }
    }
}