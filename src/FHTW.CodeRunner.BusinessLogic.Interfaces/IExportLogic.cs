// <copyright file="IExportLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    /// <summary>
    /// Interface for export actions.
    /// </summary>
    public interface IExportLogic
    {
        /// <summary>
        /// Function for exporting an exercise.
        /// </summary>
        /// <param name="exportExercise">Needed data that defines a specific exercise.</param>
        /// <returns>The xml string.</returns>
        string ExportExercise(ExportExercise exportExercise);

        /// <summary>
        /// Function for exporting a collection.
        /// </summary>
        /// <param name="collection">Needed data for exporting a specific collection.</param>
        void ExportCollection(Collection collection);
    }
}
