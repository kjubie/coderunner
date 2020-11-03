﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class TestCase
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "orderUsed")]
        public int? OrderUsed { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "standardInput")]
        public string StandardInput { get; set; }

        [DataMember(Name = "expectedOutput")]
        public string ExpectedOutput { get; set; }

        [DataMember(Name = "additionalData")]
        public string AdditionalData { get; set; }

        [DataMember(Name = "points")]
        public int? Points { get; set; }

        [DataMember(Name = "testSuiteId")]
        public int FkTestSuiteId { get; set; }

        [DataMember(Name = "testSuite")]
        public TestSuite FkTestSuite { get; set; }
    }
}