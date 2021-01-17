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
    /// <summary>
    /// The exercise header only contains written language specific data of the exercise.
    /// For programming language specific information see <see cref="ExerciseBody"/>.
    /// </summary>
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

        /// <inheritdoc/>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the full title of the exercise that is visible to the person taking the quiz.
        /// </summary>
        [Required]
        [Column("full_title")]
        [StringLength(255)]
        public string FullTitle { get; set; }

        /// <summary>
        /// Gets or Sets the introduction to the exercise.
        /// </summary>
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

        /// <summary>
        /// Gets or Sets the exercise language entity.
        /// </summary>
        [InverseProperty("FkExerciseHeader")]
        public virtual ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
