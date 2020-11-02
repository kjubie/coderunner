using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            CollectionExercise = new HashSet<CollectionExercise>();
            ExerciseBody = new HashSet<ExerciseBody>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
