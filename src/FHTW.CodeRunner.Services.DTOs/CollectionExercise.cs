// <copyright file="CollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class CollectionExercise
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "collectionLanguageId")]
        public int FkCollectionLanguageId { get; set; }

        [DataMember(Name = "versionNumber")]
        public int VersionNumber { get; set; }

        [DataMember(Name = "exerciseId")]
        public int FkExerciseId { get; set; }

        [DataMember(Name = "programmingLanguageId")]
        public int FkProgrammingLanguageId { get; set; }

        [DataMember(Name = "writtenLanguageId")]
        public int FkWrittenLanguageId { get; set; }

        [DataMember(Name = "collectionLanguage")]
        public CollectionLanguage FkCollectionLanguage { get; set; }

        [DataMember(Name = "exercise")]
        public Exercise FkExercise { get; set; }

        [DataMember(Name = "programmingLanguage")]
        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        [DataMember(Name = "writtenLanguage")]
        public WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
