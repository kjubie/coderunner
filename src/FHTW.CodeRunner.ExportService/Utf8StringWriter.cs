// <copyright file="Utf8StringWriter.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using FHTW.CodeRunner.ExportService.Entities;
using FHTW.CodeRunner.ExportService.Interfaces;

namespace FHTW.CodeRunner.ExportService
{
    /// <summary>
    /// String Writer that uses Utf8.
    /// </summary>
    public class Utf8StringWriter : StringWriter
    {
        /// <inheritdoc/>
        public override Encoding Encoding => Encoding.UTF8;
    }
}
