using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class ExerciseLanguage
    {
        public ExerciseLanguage()
        {
            ExerciseBody = new HashSet<ExerciseBody>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "writtenLanguageId")]
        public int FkWrittenLanguageId { get; set; }

        [DataMember(Name = "exerciseVersionId")]
        public int FkExerciseVersionId { get; set; }

        [DataMember(Name = "exerciseHeaderId")]
        public int FkExerciseHeaderId { get; set; }

        [DataMember(Name = "exerciseHeader")]
        public ExerciseHeader FkExerciseHeader { get; set; }

        [DataMember(Name = "exerciseVersion")]
        public ExerciseVersion FkExerciseVersion { get; set; }

        [DataMember(Name = "writtenLanguage")]
        public WrittenLanguage FkWrittenLanguage { get; set; }

        [DataMember(Name = "exerciseBody")]
        public ICollection<ExerciseBody> ExerciseBody { get; set; }
    }
}
