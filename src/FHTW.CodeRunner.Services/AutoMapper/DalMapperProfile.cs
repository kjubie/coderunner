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
            this.CreateMap<BlEntities.User, DalEntities.User>()
                .ReverseMap();

            this.CreateMap<BlEntities.Collection, DalEntities.Collection>()
                .ForMember(dest => dest.FkUser, opt => opt.Ignore());

            this.CreateMap<DalEntities.Collection, BlEntities.Collection>();

            this.CreateMap<BlEntities.CollectionExercise, DalEntities.CollectionExercise>()
                .ReverseMap();

            this.CreateMap<BlEntities.CollectionLanguage, DalEntities.CollectionLanguage>()
                .ForMember(dest => dest.FkWrittenLanguage, opt => opt.Ignore());

            this.CreateMap<DalEntities.CollectionLanguage, BlEntities.CollectionLanguage>();

            this.CreateMap<BlEntities.CollectionTag, DalEntities.CollectionTag>()
                .ReverseMap();

            this.CreateMap<BlEntities.Comment, DalEntities.Comment>()
                .ReverseMap();

            this.CreateMap<BlEntities.Difficulty, DalEntities.Difficulty>()
                .ReverseMap();

            this.CreateMap<BlEntities.Exercise, DalEntities.Exercise>()
                .ForMember(dest => dest.FkUser, opt => opt.Ignore());

            this.CreateMap<DalEntities.Exercise, BlEntities.Exercise>();

            this.CreateMap<BlEntities.ExerciseBody, DalEntities.ExerciseBody>()
                .ForMember(dest => dest.FkProgrammingLanguage, opt => opt.Ignore());

            this.CreateMap<DalEntities.ExerciseBody, BlEntities.ExerciseBody>();

            this.CreateMap<BlEntities.ExerciseHeader, DalEntities.ExerciseHeader>()
                .ReverseMap();

            this.CreateMap<BlEntities.ExerciseLanguage, DalEntities.ExerciseLanguage>()
                .ForMember(dest => dest.FkWrittenLanguage, opt => opt.Ignore());

            this.CreateMap<DalEntities.ExerciseLanguage, BlEntities.ExerciseLanguage>();

            this.CreateMap<BlEntities.ExerciseTag, DalEntities.ExerciseTag>()
                .ReverseMap();

            this.CreateMap<BlEntities.ExerciseVersion, DalEntities.ExerciseVersion>()
                .ForMember(dest => dest.FkUser, opt => opt.Ignore())
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.ValidState, opt => opt.MapFrom(src => BlEntities.ValidState.NotChecked));

            this.CreateMap<DalEntities.ExerciseVersion, BlEntities.ExerciseVersion>();

            this.CreateMap<BlEntities.ProgrammingLanguage, DalEntities.ProgrammingLanguage>()
                .ReverseMap();

            this.CreateMap<BlEntities.Rating, DalEntities.Rating>()
                .ReverseMap();

            this.CreateMap<BlEntities.Tag, DalEntities.Tag>()
                .ReverseMap();

            this.CreateMap<BlEntities.TestCase, DalEntities.TestCase>()
                .ReverseMap();

            this.CreateMap<BlEntities.TestSuite, DalEntities.TestSuite>()
                .ForMember(dest => dest.FkQuestionType, opt => opt.Ignore());

            this.CreateMap<DalEntities.TestSuite, BlEntities.TestSuite>();

            this.CreateMap<BlEntities.WrittenLanguage, DalEntities.WrittenLanguage>()
                .ReverseMap();

            this.CreateMap<BlEntities.QuestionType, DalEntities.QuestionType>()
                .ReverseMap();

            this.CreateMap<DalEntities.ExerciseInstance, BlEntities.ExerciseInstance>();

            this.CreateMap<DalEntities.CollectionInstance, BlEntities.CollectionInstance>();

            this.CreateMap<BlEntities.ExerciseKeys, DalEntities.CollectionExercise>().ReverseMap();

            this.CreateMap<DalEntities.MinimalExercise, BlEntities.ExerciseShort>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagList))
                .ForMember(dest => dest.WrittenLanguages, opt => opt.MapFrom(src => src.WrittenLanguageList))
                .ForMember(dest => dest.ProgrammingLanguages, opt => opt.MapFrom(src => src.ProgrammingLanguageList))
                .ForMember(dest => dest.FkUser, opt => opt.MapFrom(src => src.User));

            this.CreateMap<DalEntities.Exercise, BlEntities.ExerciseShort>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ExerciseTag.Select(et => et.FkTag).ToList()))
                .ForMember(dest => dest.WrittenLanguages, opt => opt.MapFrom(src => src.ExerciseVersion.SelectMany(ev => ev.ExerciseLanguage.Select(el => el.FkWrittenLanguage)).Distinct().ToList()))
                .ForMember(dest => dest.ProgrammingLanguages, opt => opt.MapFrom(src => src.ExerciseVersion.SelectMany(ev => ev.ExerciseLanguage.SelectMany(el => el.ExerciseBody.Select(eb => eb.FkProgrammingLanguage))).Distinct().ToList()));
        }
    }
}
