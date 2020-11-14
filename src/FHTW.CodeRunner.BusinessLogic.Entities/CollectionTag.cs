// <copyright file="CollectionTag.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class CollectionTag
    {
        public int Id { get; set; }

        public Collection FkCollection { get; set; }

        public Tag FkTag { get; set; }
    }
}
