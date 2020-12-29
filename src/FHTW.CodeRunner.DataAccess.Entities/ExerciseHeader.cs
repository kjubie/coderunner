// <copyright file="ExerciseHeader.cs" company="FHTW CodeRunner">
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
    [Table("exercise_header")]
    public partial class ExerciseHeader : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseHeader"/> class.
        /// </summary>
        public ExerciseHeader()
        {
            this.ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("full_title")]
        [StringLength(255)]
        public string FullTitle { get; set; }

        [Column("introduction")]
        public string Introduction { get; set; }

        /// <summary>
        /// Gets or Sets the template parameter for the exercise.
        /// </summary>
        [Column("template_param")]
        public string TemplateParam { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether the template parameter namespace can be omitted.
        /// </summary>
        [Column("template_param_lift_flag")]
        public bool TemplateParamLiftFlag { get; set; }

        /// <summary>
        /// Gets or Sets a value indicating whether twig should be used for every field.
        /// </summary>
        [Column("twig_all_flag")]
        public bool TwigAllFlag { get; set; }

        [InverseProperty("FkExerciseHeader")]
        public virtual ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
