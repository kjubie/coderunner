using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseVersion
    {
        public ExerciseVersion()
        {
            ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        public int Id { get; set; }

        public int VersionNumber { get; set; }

        public int? CreatorRating { get; set; }

        public int? CreatorDifficulty { get; set; }

        public DateTime LastModified { get; set; }

        public int FkUserId { get; set; }

        public int FkExerciseId { get; set; }

        public Exercise FkExercise { get; set; }

        public Benutzer FkUser { get; set; }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
