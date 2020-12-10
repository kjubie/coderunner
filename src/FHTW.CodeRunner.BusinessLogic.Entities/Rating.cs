// <copyright file="Rating.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    [ExcludeFromCodeCoverage]
    public class Rating
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public User FkUser { get; set; }
    }
}
