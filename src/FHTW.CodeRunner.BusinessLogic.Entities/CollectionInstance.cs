// <copyright file="CollectionInstance.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Enity for exporting the collection.
    /// </summary>
    public class CollectionInstance
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the author.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        public CollectionLanguage Header { get; set; }

        /// <summary>
        /// Gets or sets multiple exercises.
        /// </summary>
        public ICollection<ExerciseInstance> Exercises { get; set; }
    }
}
