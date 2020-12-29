// <copyright file="CollectionInstance.cs" company="FHTW CodeRunner">
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
    public class CollectionInstance
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public DateTime Created { get; init; }

        public User User { get; init; }

        public CollectionLanguage Header { get; init; }

        public ICollection<ExerciseInstance> Exercises { get; init; }
    }
}
