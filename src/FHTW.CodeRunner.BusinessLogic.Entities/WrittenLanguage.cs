using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class WrittenLanguage
    {
        public WrittenLanguage()
        {
            CollectionExercise = new HashSet<CollectionExercise>();
            ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CollectionExercise> CollectionExercise { get; set; }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
