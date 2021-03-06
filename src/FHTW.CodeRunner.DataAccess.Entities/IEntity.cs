// <copyright file="IEntity.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.DataAccess.Entities
{
    /// <summary>
    /// The interface for all entities.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or Sets the id of the entity.
        /// </summary>
        public int Id { get; set; }
    }
}
