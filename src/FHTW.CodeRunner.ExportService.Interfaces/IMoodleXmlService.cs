// <copyright file="IMoodleXmlService.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.ExportService.Interfaces
{
    public interface IMoodleXmlService
    {
        public string ExportMoodleXml(Quiz quiz);

        public Quiz ImportMoodleXml();
    }
}
