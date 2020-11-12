// <copyright file="CollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class CollectionExercise
    {
        public int Id { get; set; }

        public int VersionNumber { get; set; }

        public CollectionLanguage FkCollectionLanguage { get; set; }

        public Exercise FkExercise { get; set; }

        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        public WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
