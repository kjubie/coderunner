using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.BusinessLogic.Entities;

namespace FHTW.CodeRunner.BusinessLogic.Interfaces
{
    public interface IExerciseLogic
    {
        Exercise GetTestExercise(int id);
    }
}
