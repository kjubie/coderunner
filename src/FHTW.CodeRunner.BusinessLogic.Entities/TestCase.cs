﻿using System;
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

        public int FkTestSuiteId { get; set; }

        public TestSuite FkTestSuite { get; set; }
    }
}