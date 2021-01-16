// <copyright file="CollectionConverter.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Entities;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.Services.Converters
{
    /// <summary>
    /// AutoMapper Converter for the imported quiz data and Collection.
    /// </summary>
    public class CollectionConverter : ITypeConverter<BlEntities.PreparedImportData, BlEntities.Collection>
    {
        /// <inheritdoc/>
        public Collection Convert(PreparedImportData source, Collection destination, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
