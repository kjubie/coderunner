// <copyright file="User.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }
}
