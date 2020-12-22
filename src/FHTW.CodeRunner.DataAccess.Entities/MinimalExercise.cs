// <copyright file="MinimalExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    [NotMapped]
    public class MinimalExercise
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public User User { get; set; }

        public ICollection<Tag> TagList { get; set; }

        public ICollection<WrittenLanguage> writtenLanguageList { get; set; }

        public ICollection<ProgrammingLanguage> programmingLanguageList { get; set; }
    }
}
