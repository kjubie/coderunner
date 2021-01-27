using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// Entity that describes the needed information for a search for exercises in the database.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ExerciseSearch
    {
        /// <summary>
        /// Gets or sets the search term.
        /// </summary>
        public string SearchTerm{ get; set; }

        /// <summary>
        /// Gets or sets the written language.
        /// </summary>
        public string WrittenLanguage { get; set; }

        /// <summary>
        /// Gets or sets the programming language.
        /// </summary>
        public string ProgrammingLanguage { get; set; }
    }
}
