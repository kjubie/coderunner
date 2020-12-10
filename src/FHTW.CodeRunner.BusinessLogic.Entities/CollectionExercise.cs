// <copyright file="CollectionExercise.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class CollectionExercise
    {
        public int VersionNumber { get; set; }

        public CollectionLanguage FkCollectionLanguage { get; set; }

        public Exercise FkExercise { get; set; }

        public ProgrammingLanguage FkProgrammingLanguage { get; set; }

        public WrittenLanguage FkWrittenLanguage { get; set; }
    }
}
