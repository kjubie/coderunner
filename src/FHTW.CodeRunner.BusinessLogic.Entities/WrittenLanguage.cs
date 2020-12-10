// <copyright file="WrittenLanguage.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class WrittenLanguage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WrittenLanguage"/> class.
        /// </summary>
        public WrittenLanguage()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
