// <copyright file="CollectionInstance.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class CollectionInstance
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Created { get; set; }

        public User User { get; set; }

        public CollectionLanguage Header { get; set; }

        public ICollection<ExerciseInstance> Exercises { get; set; }
    }
}
