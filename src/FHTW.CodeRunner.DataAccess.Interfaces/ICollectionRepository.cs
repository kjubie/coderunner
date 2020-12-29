// <copyright file="ICollectionRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    public interface ICollectionRepository
    {
        ICollection<ExerciseInstance> GetExercisesInstances(int id);

        CollectionInstance GetCollectionInstance(int id);
    }
}
