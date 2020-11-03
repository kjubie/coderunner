using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            return context.Exercise
                    .Include(e => e.FkUser)
                    .Include(e => e.ExerciseVersion)
                        .ThenInclude(v => v.FkUser)
                    .Include(e => e.ExerciseVersion)
                        .ThenInclude(v => v.ExerciseLanguage)
                            .ThenInclude(el => el.FkWrittenLanguage)
                            .AsEnumerable()
                    .FirstOrDefault(e => e.Id == id);
            //throw new NotImplementedException();
        }
    }
}
