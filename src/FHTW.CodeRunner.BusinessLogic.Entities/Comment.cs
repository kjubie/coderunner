// <copyright file="Comment.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public Exercise FkExercise { get; set; }

        public User FkUser { get; set; }
    }
}
