// <copyright file="QuestionType.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [ExcludeFromCodeCoverage]
    [Table("questiontype")]
    public class QuestionType : IEntity
    {
        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        [StringLength(64)]
        public string Name { get; set; }

        [Column("fk_programming_language_id")]
        public int FkProgrammingLanuageId { get; set; }

        [ForeignKey("FkProgrammingLanuageId")]
        public virtual ProgrammingLanguage FkProgrammingLanguage { get; set; }
    }
}
