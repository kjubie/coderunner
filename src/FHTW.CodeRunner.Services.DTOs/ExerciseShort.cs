using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExerciseShort
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "created")]
        public DateTime Created { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }

        [DataMember(Name = "tagList")]
        public List<Tag> Tags { get; set; }

        [DataMember(Name = "writtenLanguageList")]
        public List<WrittenLanguage> WrittenLanguages { get; set; }

        [DataMember(Name = "programmingLanguageList")]
        public List<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    }
}
