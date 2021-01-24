using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    /// <summary>
    /// A minimal version of the collection entity.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MinimalCollection
    {
        /// <summary>
        /// Gets or sets the id of the collection.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the collection.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the collection.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the count of the amount of exercises in the collection.
        /// </summary>
        public int ExerciseCount { get; set; }

        /// <summary>
        /// Gets or sets the user that created the collection.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets a list of written languages, in which the collection is available in.
        /// </summary>
        public List<WrittenLanguage> WrittenLanguageList { get; set; }

        /// <summary>
        /// Gets or sets a list of tags.
        /// </summary>
        public List<Tag> TagList { get; set; }
    }
}
