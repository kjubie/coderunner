using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class ExportExercise
    {
        public int Id { get; set; }

        public int Version { get; set; }

        public string WrittenLanguage { get; set; }

        public string ProgrammingLanguage { get; set; }
    }
}
