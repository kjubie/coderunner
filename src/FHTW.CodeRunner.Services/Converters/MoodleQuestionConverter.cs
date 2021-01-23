// <copyright file="MoodleQuestionConverter.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.Services.Helpers;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.Services.Converters
{
    /// <summary>
    /// AutoMapper Converter for the Moodle Question and Exercise.
    /// </summary>
    public class MoodleQuestionConverter : ITypeConverter<BlEntities.ImportData, BlEntities.Exercise>
    {
        /// <inheritdoc/>
        public BlEntities.Exercise Convert(BlEntities.ImportData source, BlEntities.Exercise destination, ResolutionContext context)
        {
            MarkdownHtmlHandler markdownHtmlHandler = new MarkdownHtmlHandler();
            int x; // TODO: Test it!

            if (source?.Question == null)
            {
                return null;
            }

            var question = source.Question;

            BlEntities.Exercise exercise = new BlEntities.Exercise
            {
                Id = 0,
                Title = question.Name?.Text,
                Created = DateTime.Now,
                FkUser = null,
                FkUserId = source.User.Id,
                ExerciseTag = new List<BlEntities.ExerciseTag>(),
                ExerciseVersion = new List<BlEntities.ExerciseVersion>(),
            };

            var tags = question.Tags?.Tag;
            if (tags != null)
            {
                foreach (var tag in tags)
                {
                    var exerciseTag = new BlEntities.ExerciseTag
                    {
                        Id = 0,
                        FkTag = new BlEntities.Tag
                        {
                            Id = 0,
                            Name = tag.Text,
                        },
                    };

                    exercise.ExerciseTag.Add(exerciseTag);
                }
            }

            var exerciseVersion = new BlEntities.ExerciseVersion
            {
                Id = 0,
                VersionNumber = 0,
                CreatorRating = 0,
                CreatorDifficulty = 0,
                LastModified = DateTime.Now,
                ValidState = BlEntities.ValidState.NotChecked,
                FkUser = null,
                FkUserId = source.User.Id,
                ExerciseLanguage = new List<BlEntities.ExerciseLanguage>(),
            };

            var exerciseLanguage = new BlEntities.ExerciseLanguage
            {
                Id = 0,
                FkExerciseHeader = new BlEntities.ExerciseHeader
                {
                    Id = 0,
                    FullTitle = question.Name?.Text,
                    Introduction = string.Empty,
                    TemplateParam = question.Templateparams,
                    TemplateParamLiftFlag = question.Hoisttemplateparams == "1" ? true : false,
                    TwigAllFlag = question.Twigall == "1" ? true : false,
                },
                FkWrittenLanguage = null,
                FkWrittenLanguageId = source.WrittenLanguage.Id,
                ExerciseBody = new List<BlEntities.ExerciseBody>(),
            };

            var exerciseBody = new BlEntities.ExerciseBody
            {
                Id = 0,
                Description = markdownHtmlHandler.HtmlToMarkdown(question.Questiontext?.Text),
                Hint = string.Empty, // TODO: Hint?
                FieldLines = int.TryParse(question.Answerboxlines, out x) ? x : 0,
                GradingFlag = question.Allornothing == "1" ? true : false,
                SubtractSystem = question.Penaltyregime,
                ObtainablePoints = int.TryParse(question.Defaultgrade, out x) ? x : 0,
                IdNum = int.TryParse(question.Idnumber, out x) ? x : 0,
                Solution = question.Answer,
                Prefill = question.Answerpreload,
                Feedback = markdownHtmlHandler.HtmlToMarkdown(question.Generalfeedback?.Text),
                AllowFiles = int.TryParse(question.Attachments, out x) ? x : 0,
                FilesRequired = int.TryParse(question.Attachmentsrequired, out x) ? x : 0,
                FilesRegex = question.Filenamesregex,
                FilesDescription = question.Filenamesexplain,
                FilesSize = int.TryParse(question.Maxfilesize, out x) ? x : 0,
                FkProgrammingLanguage = null,
                FkProgrammingLanguageId = source.ProgrammingLanguage.Id,
            };

            var testSuite = new BlEntities.TestSuite
            {
                Id = 0,
                FkQuestionType = null,
                FkQuestionTypeId = source.QuestionType.Id,
                TemplateDebugFlag = question.Showsource == "1" ? true : false,
                TestOnSaveFlag = question.Validateonsave == "1" ? true : false,
                GlobalExtraParam = question.Globalextra,
                RuntimeData = string.Empty, // TODO: RuntimeData? File im Moodle. Pls add.
                PreCheck = int.TryParse(question.Precheck, out x) ? (BlEntities.PreCheckState)x : BlEntities.PreCheckState.Deactivated, // TODO: Errorhandling
                GeneralFeedbackDisplay = int.TryParse(question.Displayfeedback, out x) ? (BlEntities.GeneralFeedbackDisplayState)x : BlEntities.GeneralFeedbackDisplayState.SetFromTest, // TODO: Errorhandling
                TestCase = new List<BlEntities.TestCase>(),
            };

            var testCases = question.Testcases?.Testcase;
            if (testCases != null)
            {
                foreach (var testCase in testCases)
                {
                    var exerciseTestCase = new BlEntities.TestCase
                    {
                        Id = 0,
                        OrderUsed = 0, // TODO: OrderUsed?
                        TestCode = testCase.Testcode?.Text,
                        StandardInput = testCase.Stdin?.Text,
                        ExpectedOutput = testCase.Expected?.Text,
                        AdditionalData = testCase.Extra?.Text,
                        Points = int.TryParse(testCase.Mark, out x) ? x : null,
                        UseAsExampleFlag = testCase.Useasexample == "1" ? true : false,
                        HideOnFailFlag = testCase.Hiderestiffail == "1" ? true : false,
                        DisplayType = testCase.Display?.Text,
                    };

                    testSuite.TestCase.Add(exerciseTestCase);
                }
            }
            

            exerciseBody.FkTestSuite = testSuite;
            exerciseLanguage.ExerciseBody.Add(exerciseBody);
            exerciseVersion.ExerciseLanguage.Add(exerciseLanguage);
            exercise.ExerciseVersion.Add(exerciseVersion);

            return exercise;
        }
    }
}
