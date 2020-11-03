using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class TestSuite
    {
        public TestSuite()
        {
            ExerciseBody = new HashSet<ExerciseBody>();
            TestCase = new HashSet<TestCase>();
        }

        public int Id { get; set; }

        public string QuestionType { get; set; }

        public string Prefill { get; set; }

        public string Solution { get; set; }

        public int? Complexity { get; set; }

        public ICollection<ExerciseBody> ExerciseBody { get; set; }

        public ICollection<TestCase> TestCase { get; set; }
    }
}
