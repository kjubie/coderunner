﻿// <copyright file="Quiz.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Xml.Serialization;

namespace FHTW.CodeRunner.ExportService.Entities
{
    [XmlRoot(ElementName = "quiz")]
    public class Quiz
    {
        [XmlElement(ElementName = "question")]
        public List<Question> Question { get; set; }
    }
}