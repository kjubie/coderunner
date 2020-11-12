// <copyright file="DalMapperProfile.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using DalEntities = FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.Services.AutoMapper
{
    /// <summary>
    /// A class that contains the used mapping for the business section.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DalMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DalMapperProfile"/> class.
        /// </summary>
        public DalMapperProfile()
        {
            this.CreateMap<BlEntities.Benutzer, DalEntities.User>()
                .ReverseMap();

            this.CreateMap<BlEntities.Collection, DalEntities.Collection>()
                .ReverseMap();

            this.CreateMap<BlEntities.CollectionExercise, DalEntities.CollectionExercise>()
                .ReverseMap();

            this.CreateMap<BlEntities.CollectionLanguage, DalEntities.CollectionLanguage>()
                .ReverseMap();

            this.CreateMap<BlEntities.CollectionTag, DalEntities.CollectionTag>()
                .ReverseMap();

            this.CreateMap<BlEntities.Comment, DalEntities.Comment>()
                .ReverseMap();

            this.CreateMap<BlEntities.Difficulty, DalEntities.Difficulty>()
                .ReverseMap();

            this.CreateMap<BlEntities.Exercise, DalEntities.Exercise>()
                .ReverseMap();

            this.CreateMap<BlEntities.ExerciseBody, DalEntities.ExerciseBody>()
                .ReverseMap();

            this.CreateMap<BlEntities.ExerciseHeader, DalEntities.ExerciseHeader>()
                .ReverseMap();

            this.CreateMap<BlEntities.ExerciseLanguage, DalEntities.ExerciseLanguage>()
                .ReverseMap();

            this.CreateMap<BlEntities.ExerciseTag, DalEntities.ExerciseTag>()
                .ReverseMap();

            this.CreateMap<BlEntities.ExerciseVersion, DalEntities.ExerciseVersion>()
                .ReverseMap();

            this.CreateMap<BlEntities.ProgrammingLanguage, DalEntities.ProgrammingLanguage>()
                .ReverseMap();

            this.CreateMap<BlEntities.Rating, DalEntities.Rating>()
                .ReverseMap();

            this.CreateMap<BlEntities.Tag, DalEntities.Tag>()
                .ReverseMap();

            this.CreateMap<BlEntities.TestCase, DalEntities.TestCase>()
                .ReverseMap();

            this.CreateMap<BlEntities.TestSuite, DalEntities.TestSuite>()
                .ReverseMap();

            this.CreateMap<BlEntities.WrittenLanguage, DalEntities.WrittenLanguage>()
                .ReverseMap();
        }
    }
}
