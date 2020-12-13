// <copyright file="IExerciseLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    public interface IExerciseLogic
    {
        Exercise GetTestExercise(int id);

        public void SaveExercise(Exercise exercise);

        public void ValidateExercise(Exercise exercise);
    }
}
