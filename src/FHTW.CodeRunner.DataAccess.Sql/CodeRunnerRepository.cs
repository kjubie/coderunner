using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using System;
using System.Linq;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    public class CodeRunnerRepository : IRepository
    {
        private readonly CodeRunnerContext context;

        public CodeRunnerRepository(CodeRunnerContext dbcontext) => context = dbcontext;

        Exercise IRepository.GetExerciseById(int id)
        {
            return context.Exercise.Single(exercise => exercise.Id == id);
            //throw new NotImplementedException();
        }
    }
}
