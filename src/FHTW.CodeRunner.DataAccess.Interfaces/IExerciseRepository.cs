using FHTW.CodeRunner.DataAccess.Entities;
using System;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    public interface IExerciseRepository
    {
        Exercise GetExerciseById(int id);
    }
}
