// <copyright file="IImportLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface for dealing with import actions.
    /// </summary>
    public interface IImportLogic
    {
        /// <summary>
        /// Function for imporing a collection.
        /// </summary>
        /// <param name="importData">The moodle quiz as xml string and needed data.</param>
        void ImportCollection(ImportData importData);
    }
}
