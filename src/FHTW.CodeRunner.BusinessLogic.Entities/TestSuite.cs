// <copyright file="TestSuite.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class TestSuite
    {
        public TestSuite()
        {
            this.TestCase = new HashSet<TestCase>();
        }

        public int Id { get; set; }

        public string QuestionType { get; set; }

        public string Prefill { get; set; }

        public string Solution { get; set; }

        public int? Complexity { get; set; }

        public ICollection<TestCase> TestCase { get; set; }
    }
}
