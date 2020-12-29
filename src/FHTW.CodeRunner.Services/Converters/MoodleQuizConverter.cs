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

                var header = exerciseInstance.Header;
                if (header != null)
                {
                    question.Name.Text = header.FullTitle;
                }

                var body = exerciseInstance.Body;
                if (body != null)
                {
                    question.Questiontext.Format = "html";
                    question.Questiontext.Text = body.Description;

                    question.Generalfeedback.Format = "html";
                    question.Generalfeedback.Text = body.Feedback;

                    question.Defaultgrade = body.OptainablePoints.ToString();
                    question.Penalty = string.Empty; // TODO
                    question.Hidden = "0"; // TODO
                    question.Idnumber = body.IdNum.ToString();

                    question.Prototypetype = string.Empty; // TODO
                    question.Allornothing = string.Empty; // TODO
                    question.Penaltyregime = body.SubtractSystem;
                    question.Precheck = string.Empty; // TODO
                    question.Showsource = string.Empty; // TODO
                    question.Answerboxlines = body.FieldLines.ToString();
                    question.Answerboxcolumns = string.Empty;
                    question.Answerpreload = body.Prefill;
                    question.Globalextra = string.Empty; // TODO
                    question.Useace = string.Empty; // TODO
                    question.Resultcolumns = string.Empty; // TODO
                    question.Template = string.Empty; // TODO
                    question.Iscombinatortemplate = string.Empty; // TODO
                    question.Allowmultiplestdins = string.Empty; // TODO
                    question.Answer = string.Empty; // TODO
                    question.Validateonsave = string.Empty; // TODO
                    question.Testsplitterre = string.Empty; // TODO
                    question.Language = string.Empty; // TODO
                    question.Acelang = string.Empty; // TODO
                    question.Sandbox = string.Empty; // TODO
                    question.Grader = string.Empty; // TODO
                    question.Cputimelimitsecs = string.Empty; // TODO
                    question.Memlimitmb = string.Empty; // TODO
                    question.Sandboxparams = string.Empty; // TODO
                    question.Templateparams = string.Empty; // TODO
                    question.Hoisttemplateparams = string.Empty; // TODO
                    question.Twigall = string.Empty; // TODO
                    question.Uiplugin = string.Empty; // TODO
                    question.Attachments = string.Empty; // TODO
                    question.Attachmentsrequired = string.Empty; // TODO
                    question.Maxfilesize = string.Empty; // TODO
                    question.Filenamesregex = string.Empty; // TODO
                    question.Filenamesexplain = string.Empty; // TODO
                    question.Displayfeedback = string.Empty; // TODO
                }

                var testSuite = exerciseInstance.TestSuite;
                if (testSuite != null)
                {
                    question.Coderunnertype = testSuite.FkQuestionType == null ? string.Empty : testSuite.FkQuestionType.Name;

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

                            newTestCase.Testtype = string.Empty; // TODO
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

                quiz.Question.Add(question);
            }

            destination = quiz;

            return destination;
        }
    }
}
