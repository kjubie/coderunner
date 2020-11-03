﻿using System;
using System.Collections.Generic;

namespace FHTW.CodeRunner.BusinessLogic.Entities
{
    public class CollectionLanguage
    {
        public CollectionLanguage()
        {
            CollectionExercise = new HashSet<CollectionExercise>();
        }

        public int Id { get; set; }

        public string FullTitle { get; set; }

        public string ShortTitle { get; set; }

        public string Introduction { get; set; }

        public int FkCollectionId { get; set; }

        public Collection FkCollection { get; set; }

        public ICollection<CollectionExercise> CollectionExercise { get; set; }
    }
}