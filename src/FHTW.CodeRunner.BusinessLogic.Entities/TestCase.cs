// <copyright file="TestCase.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class TestCase
    {
        public int Id { get; set; }

        public int? OrderUsed { get; set; }

        public string Description { get; set; }

        public string StandardInput { get; set; }

        public string ExpectedOutput { get; set; }

        public string AdditionalData { get; set; }

        public int? Points { get; set; }

        public TestSuite FkTestSuite { get; set; }
    }
}
