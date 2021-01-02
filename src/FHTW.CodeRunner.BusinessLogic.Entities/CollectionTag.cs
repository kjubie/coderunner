﻿// <copyright file="CollectionTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Enity for defining the tags in a collection.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CollectionTag
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        public Tag FkTag { get; set; }
    }
}
