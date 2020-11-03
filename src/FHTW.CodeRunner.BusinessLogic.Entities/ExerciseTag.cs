using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class ExerciseTag
    {
        public int Id { get; set; }

        public int FkTagId { get; set; }

        public int FkExerciseId { get; set; }

        public Exercise FkExercise { get; set; }

        public Tag FkTag { get; set; }
    }
}
