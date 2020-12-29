using System;
using System.Collections.Generic;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseInstance
    {
        /// <summary>
        /// Gets or sets the id of the exercise.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the exercise.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the exercise.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the user that the created/owns the exercise.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the written language of the exercise.
        /// </summary>
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the programming language of the exercise.
        /// </summary>
        public string ProgrammingLanguage { get; set; }

        /// <summary>
        /// Gets or sets the version of the exericse.
        /// </summary>
        public ExerciseVersion Version { get; set; }

        /// <summary>
        /// Gets or sets the header of the exercise.
        /// </summary>
        public ExerciseHeader Header { get; set; }

        /// <summary>
        /// Gets or sets the body of the exercise.
        /// </summary>
        public ExerciseBody Body { get; set; }

        /// <summary>
        /// Gets or sets the test suite.
        /// </summary>
        public TestSuite TestSuite { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the exercise is valid.
        /// </summary>
        public bool IsValid { get; set; }
    }
}
