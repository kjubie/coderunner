using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using SvcEntities = FHTW.CodeRunner.Services.DTOs;

namespace FHTW.CodeRunner.Services.AutoMapper
{
    /// <summary>
    /// A class that contains the used mapping for the business section.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class BlMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlMapperProfile"/> class.
        /// </summary>
        public BlMapperProfile()
        {
            this.CreateMap<SvcEntities.Benutzer, BlEntities.Benutzer>()
                .ReverseMap();

            this.CreateMap<SvcEntities.Collection, BlEntities.Collection>()
                .ReverseMap();

            this.CreateMap<SvcEntities.CollectionExercise, BlEntities.CollectionExercise>()
                .ReverseMap();

            this.CreateMap<SvcEntities.CollectionLanguage, BlEntities.CollectionLanguage>()
                .ReverseMap();

            this.CreateMap<SvcEntities.CollectionTag, BlEntities.CollectionTag>()
                .ReverseMap();

            this.CreateMap<SvcEntities.Comment, BlEntities.Comment>()
                .ReverseMap();

            this.CreateMap<SvcEntities.Difficulty, BlEntities.Difficulty>()
                .ReverseMap();

            this.CreateMap<SvcEntities.Exercise, BlEntities.Exercise>()
                .ReverseMap();

            this.CreateMap<SvcEntities.ExerciseBody, BlEntities.ExerciseBody>()
                .ReverseMap();

            this.CreateMap<SvcEntities.ExerciseHeader, BlEntities.ExerciseHeader>()
                .ReverseMap();

            this.CreateMap<SvcEntities.ExerciseLanguage, BlEntities.ExerciseLanguage>()
                .ReverseMap();

            this.CreateMap<SvcEntities.ExerciseTag, BlEntities.ExerciseTag>()
                .ReverseMap();

            this.CreateMap<SvcEntities.ExerciseVersion, BlEntities.ExerciseVersion>()
                .ReverseMap();

            this.CreateMap<SvcEntities.ProgrammingLanguage, BlEntities.ProgrammingLanguage>()
                .ReverseMap();

            this.CreateMap<SvcEntities.Rating, BlEntities.Rating>()
                .ReverseMap();

            this.CreateMap<SvcEntities.Tag, BlEntities.Tag>()
                .ReverseMap();

            this.CreateMap<SvcEntities.TestCase, BlEntities.TestCase>()
                .ReverseMap();

            this.CreateMap<SvcEntities.TestSuite, BlEntities.TestSuite>()
                .ReverseMap();

            this.CreateMap<SvcEntities.WrittenLanguage, BlEntities.WrittenLanguage>()
                .ReverseMap();
        }
    }
}
