﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FHTW.CodeRunner.Services.DTOs
{
    [DataContract]
    public class TestSuite
    {
        public TestSuite()
        {
            ExerciseBody = new HashSet<ExerciseBody>();
            TestCase = new HashSet<TestCase>();
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

        [DataMember(Name = "exerciseBodyList")]
        public ICollection<ExerciseBody> ExerciseBody { get; set; }

        [DataMember(Name = "testCaseList")]
        public ICollection<TestCase> TestCase { get; set; }
    }
}