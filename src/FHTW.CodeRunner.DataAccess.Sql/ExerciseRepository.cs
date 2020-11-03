using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using System;
using System.Linq;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly CodeRunnerContext context;

        public ExerciseRepository(CodeRunnerContext dbcontext) => context = dbcontext;

        Exercise IExerciseRepository.GetExerciseById(int id)
        {
            return context.Exercise.Single(exercise => exercise.Id == id);
            //throw new NotImplementedException();
        }
    }
}
