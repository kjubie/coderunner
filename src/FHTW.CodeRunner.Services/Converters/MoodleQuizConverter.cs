// <copyright file="MoodleQuizConverter.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlEntities = FHTW.CodeRunner.BusinessLogic.Entities;
using EsEntities = FHTW.CodeRunner.ExportService.Entities;

namespace FHTW.CodeRunner.Services.Converters
{
    public class MoodleQuizConverter : ITypeConverter<BlEntities.CollectionInstance, EsEntities.Quiz>
    {
        /// <inheritdoc/>
        public EsEntities.Quiz Convert(BlEntities.CollectionInstance source, EsEntities.Quiz destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            EsEntities.Quiz quiz = new EsEntities.Quiz
            {
                Question = new List<EsEntities.Question>(),
            };

            foreach (var exerciseInstance in source.Exercises)
            {
                EsEntities.Question question = new EsEntities.Question
                {
                    Name = new EsEntities.Name(),
                    Questiontext = new EsEntities.Questiontext(),
                    Generalfeedback = new EsEntities.Generalfeedback(),
                    Testcases = new EsEntities.Testcases(),
                    Tags = new EsEntities.Tags(),
                };

                question.Questiontext.Text = string.Empty;
                var header = exerciseInstance.Header;
                if (header != null)
                {
                    question.Name.Text = header.FullTitle;
                    question.Questiontext.Text = header.Introduction + "\n";
                    question.Templateparams = header.TemplateParam;
                    question.Hoisttemplateparams = header.TemplateParamLiftFlag == true ? "1" : "0";
                    question.Twigall = header.TwigAllFlag == true ? "1" : "0";
                }

                var body = exerciseInstance.Body;
                if (body != null)
                {
                    question.Questiontext.Format = "html";
                    question.Questiontext.Text += body.Description;

                    question.Generalfeedback.Format = "html";
                    question.Generalfeedback.Text = body.Feedback;

                    question.Defaultgrade = body.ObtainablePoints.ToString();
                    question.Idnumber = body.IdNum.ToString();

                    question.Allornothing = body.GradingFlag.ToString();
                    question.Penaltyregime = body.SubtractSystem;
                    question.Answerboxlines = body.FieldLines.ToString();

                    question.Answerpreload = body.Prefill;
                    question.Answer = body.Solution;

                    question.Attachments = body.AllowFiles.ToString();
                    question.Attachmentsrequired = body.FilesRequired.ToString();
                    question.Maxfilesize = body.FilesSize.ToString();
                    question.Filenamesregex = body.FilesRegex;
                    question.Filenamesexplain = body.FilesDescription;
                }

                var testSuite = exerciseInstance.TestSuite;
                if (testSuite != null)
                {
                    question.Coderunnertype = testSuite.FkQuestionType == null ? string.Empty : testSuite.FkQuestionType.Name;
                    question.Showsource = testSuite.TemplateDebugFlag == true ? "1" : "0";
                    question.Globalextra = testSuite.GlobalExtraParam;
                    question.Validateonsave = testSuite.TestOnSaveFlag == true ? "1" : "0";
                    question.Precheck = testSuite.PreCheck.ToString();
                    question.Displayfeedback = testSuite.GeneralFeedbackDisplay.ToString();

                    var testCases = testSuite.TestCase;
                    if (testCases != null)
                    {
                        question.Testcases.Testcase = new List<EsEntities.Testcase>();
                        foreach (var testCase in testCases)
                        {
                            EsEntities.Testcase newTestCase = new EsEntities.Testcase
                            {
                                Testcode = new EsEntities.Testcode(),
                                Stdin = new EsEntities.Stdin(),
                                Expected = new EsEntities.Expected(),
                                Extra = new EsEntities.Extra(),
                                Display = new EsEntities.Display(),
                            };

                            newTestCase.Testcode.Text = testCase.TestCode;
                            newTestCase.Stdin.Text = testCase.StandardInput;
                            newTestCase.Expected.Text = testCase.ExpectedOutput;
                            newTestCase.Extra.Text = testCase.AdditionalData;
                            newTestCase.Display.Text = testCase.DisplayType;

                            newTestCase.Testtype = "0"; // TODO: Changeable?
                            newTestCase.Useasexample = testCase.UseAsExampleFlag == true ? "1" : "0";
                            newTestCase.Hiderestiffail = testCase.HideOnFailFlag == true ? "1" : "0";
                            newTestCase.Mark = System.Convert.ToString(testCase.Points);

                            question.Testcases.Testcase.Add(newTestCase);
                        }
                    }
                }

                var tags = exerciseInstance.Tags;
                if (tags != null)
                {
                    question.Tags.Tag = new List<EsEntities.Tag>();
                    foreach (var tag in tags)
                    {
                        EsEntities.Tag newTag = new EsEntities.Tag
                        {
                            Text = tag.Name,
                        };

                        question.Tags.Tag.Add(newTag);
                    }
                }

                // TODO: The following attributes are uncertain and have to be discussed
                question.Penalty = string.Empty;
                question.Hidden = "0";
                question.Answerboxcolumns = "100";

                // The following attributes have been ignored because they were not relevant at the time of creation
                question.Prototypetype = "0";
                question.Useace = string.Empty;
                question.Resultcolumns = string.Empty;
                question.Template = string.Empty;
                question.Iscombinatortemplate = string.Empty;
                question.Allowmultiplestdins = string.Empty;
                question.Testsplitterre = string.Empty;
                question.Language = string.Empty;
                question.Acelang = string.Empty;
                question.Sandbox = string.Empty;
                question.Grader = string.Empty;
                question.Cputimelimitsecs = string.Empty;
                question.Memlimitmb = string.Empty;
                question.Sandboxparams = string.Empty;
                question.Uiplugin = string.Empty;

                quiz.Question.Add(question);
            }

            destination = quiz;

            return destination;
        }
    }
}
