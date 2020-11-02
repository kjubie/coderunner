using System;
using System.Collections.Generic;
namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Tag
    {
        public Tag()
        {
            CollectionTag = new HashSet<CollectionTag>();
            ExerciseTag = new HashSet<ExerciseTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CollectionTag> CollectionTag { get; set; }

        public ICollection<ExerciseTag> ExerciseTag { get; set; }
    }
}
