// <copyright file="ICollectionLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface for dealing with collection actions.
    /// </summary>
    public interface ICollectionLogic
    {
        /// <summary>
        /// Function retrieving a list of minimal collections.
        /// </summary>
        /// <returns>The list of minimal collections.</returns>
        public List<MinimalCollection> GetMinimalCollectionList();

        /// <summary>
        /// Function for saving a collection.
        /// </summary>
        /// <param name="collection">The incoming collection.</param>
        public void SaveCollection(Collection collection);
    }
}
