using System;
using System.Collections.Generic;
namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Rating
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int FkExerciseId { get; set; }

        public int FkUserId { get; set; }

        public Exercise FkExercise { get; set; }

        public Benutzer FkUser { get; set; }
    }
}
