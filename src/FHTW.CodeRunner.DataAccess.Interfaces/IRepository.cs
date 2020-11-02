using FHTW.CodeRunner.DataAccess.Entities;
using System;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    public interface IRepository
    {
        Exercise GetExerciseById(int id);
    }
}
