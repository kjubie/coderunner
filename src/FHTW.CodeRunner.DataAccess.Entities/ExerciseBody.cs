// <copyright file="ExerciseBody.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [Table("exercise_body")]
    public partial class ExerciseBody
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("fk_programming_language_id")]
        public int FkProgrammingLanguageId { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("example")]
        public string Example { get; set; }

        [Column("hint")]
        public string Hint { get; set; }

        [Column("fk_exercise_language_id")]
        public int FkExerciseLanguageId { get; set; }

        [Column("fk_test_suite_id")]
        public int FkTestSuiteId { get; set; }

        [ForeignKey(nameof(FkExerciseLanguageId))]
        [InverseProperty(nameof(ExerciseLanguage.ExerciseBody))]
        public virtual ExerciseLanguage FkExerciseLanguage { get; set; }

        [ForeignKey(nameof(FkProgrammingLanguageId))]
        [InverseProperty(nameof(ProgrammingLanguage.ExerciseBody))]
        public virtual ProgrammingLanguage FkProgrammingLanguage { get; set; }

        [ForeignKey(nameof(FkTestSuiteId))]
        [InverseProperty(nameof(TestSuite.ExerciseBody))]
        public virtual TestSuite FkTestSuite { get; set; }
    }
}
