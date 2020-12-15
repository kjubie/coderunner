using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseCreatePreparation
    {
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }

        public List<WrittenLanguage> WrittenLanguages { get; set; }

        public List<QuestionType> QuestionTypes { get; set; }
    }
}
