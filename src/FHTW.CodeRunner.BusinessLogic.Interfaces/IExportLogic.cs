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
        /// <param name="exerciseKeys">Needed data that defines a specific exercise.</param>
        /// <returns>The xml string.</returns>
        string ExportExercise(ExerciseKeys exerciseKeys);

        /// <summary>
        /// Function for exporting a collection.
        /// </summary>
        /// <param name="collectionKeys">Needed data for exporting a specific collection.</param>
        /// <returns>The xml string.</returns>
        string ExportCollection(CollectionKeys collectionKeys);
    }
}
