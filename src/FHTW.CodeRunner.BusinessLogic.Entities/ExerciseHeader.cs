using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseHeader
    {
        public ExerciseHeader()
        {
            ExerciseLanguage = new HashSet<ExerciseLanguage>();
        }

        public int Id { get; set; }

        public string FullTitle { get; set; }

        public string ShortTitle { get; set; }

        public string Introduction { get; set; }

        public ICollection<ExerciseLanguage> ExerciseLanguage { get; set; }
    }
}
