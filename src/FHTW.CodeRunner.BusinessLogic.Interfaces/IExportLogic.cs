// <copyright file="IExportLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    public interface IExportLogic
    {
        string ExportExercise(ExportExercise exportExercise);

        void ExportCollection(Collection collection);
    }
}
