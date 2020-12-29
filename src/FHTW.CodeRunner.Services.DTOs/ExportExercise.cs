using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class ExportExercise
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "version")]
        public int Version { get; set; }

        [DataMember(Name = "writtenLanguage")]
        public string WrittenLanguage { get; set; }

        [DataMember(Name = "programmingLanguage")]
        public string ProgrammingLanguage { get; set; }
    }
}
