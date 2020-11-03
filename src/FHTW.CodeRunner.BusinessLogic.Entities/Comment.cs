using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public int FkExerciseId { get; set; }

        public int FkUserId { get; set; }

        public Exercise FkExercise { get; set; }

        public Benutzer FkUser { get; set; }
    }
}
