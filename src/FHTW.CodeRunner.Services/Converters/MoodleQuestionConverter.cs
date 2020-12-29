// <copyright file="MoodleQuestionConverter.cs" company="FHTW CodeRunner">
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
    public class MoodleQuestionConverter : IValueConverter<BlEntities.ExerciseInstance, EsEntities.Question>, IValueConverter<EsEntities.Question, BlEntities.ExerciseInstance>
    {
        /// <inheritdoc/>
        public Question Convert(ExerciseInstance sourceMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ExerciseInstance Convert(Question sourceMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}