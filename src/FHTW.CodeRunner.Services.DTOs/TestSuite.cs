// <copyright file="TestSuite.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class TestSuite
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestSuite"/> class.
        /// </summary>
        public TestSuite()
        {
            this.TestCase = new HashSet<TestCase>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "questionType")]
        public string QuestionType { get; set; }

        [DataMember(Name = "prefill")]
        public string Prefill { get; set; }

        [DataMember(Name = "solution")]
        public string Solution { get; set; }

        [DataMember(Name = "complexity")]
        public int? Complexity { get; set; }

        [DataMember(Name = "testCaseList")]
        public ICollection<TestCase> TestCase { get; set; }
    }
}
