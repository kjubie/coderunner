// <copyright file="Tag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Tag
    {
        public Tag()
        {
            this.CollectionTag = new HashSet<CollectionTag>();
            this.ExerciseTag = new HashSet<ExerciseTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CollectionTag> CollectionTag { get; set; }

        public ICollection<ExerciseTag> ExerciseTag { get; set; }
    }
}
