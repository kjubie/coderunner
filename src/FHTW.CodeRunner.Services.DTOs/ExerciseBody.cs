using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class ExerciseBody
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "programmingLanguageId")]
        public int FkProgrammingLanguageId { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "example")]
        public string Example { get; set; }

        [DataMember(Name = "hint")]
        public string Hint { get; set; }

        [DataMember(Name = "exerciseLanguageId")]
        public int FkExerciseLanguageId { get; set; }

        [DataMember(Name = "testSuiteId")]
        public int FkTestSuiteId { get; set; }

        [DataMember(Name = "exerciseLanguage")]
        public ExerciseLanguage FkExerciseLanguage { get; set; }

        [DataMember(Name = "programmingLanguage")]
        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        [DataMember(Name = "testSuite")]
        public TestSuite FkTestSuite { get; set; }
    }
}
