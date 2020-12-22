// <copyright file="MoodleQuizConverter.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FHTW.CodeRunner.ExportService.Entities;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.Services.Converters
{
    public class MoodleQuizConverter : IValueConverter<BlEntities.Exercise, EsEntities.Quiz>, IValueConverter<EsEntities.Quiz, BlEntities.Exercise>
    {
        /// <inheritdoc/>
        public Exercise Convert(Quiz sourceMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Quiz Convert(Exercise sourceMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
