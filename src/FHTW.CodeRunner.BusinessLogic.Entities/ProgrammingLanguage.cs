// <copyright file="ProgrammingLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class ProgrammingLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProgrammingLanguage"/> class.
        /// </summary>
        public ProgrammingLanguage()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
