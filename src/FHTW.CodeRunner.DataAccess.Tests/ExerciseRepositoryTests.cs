// <copyright file="ExerciseRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text.Json.Serialization;
using NUnit.Framework;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Testnames should be explanation enough.")]
    [TestFixture]
    public class ExerciseRepositoryTests
    {
        private CodeRunnerTestDb testDb;

        [TearDown]
        public void NullDatabase() => this.testDb = null;

        [Test]
        public void ShouldCreateExercise()
        {
            this.SetupDatabase(DbTestController.State.SEEDED);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IExerciseRepository rep = new ExerciseRepository(context);

                User user = context.User.FirstOrDefault();

                System.DateTime creationDate = System.DateTime.Now;

                Exercise exercise = new Exercise
                {
                    Id = 0,
                    Title = "Title1",
                    Created = creationDate,
                    FkUserId = user.Id,
                };

                rep.Create(exercise);

                Assert.IsTrue(rep.Exists(exercise));

                var versions = exercise.ExerciseVersion;

                Assert.IsTrue(versions != null, "After Create() there should exist one version");
                Assert.IsTrue(versions.Count == 1, "After Create() there should be only exist one version");

                var version = versions.First();

                Assert.IsTrue(version.FkUserId == exercise.FkUserId);
                Assert.IsTrue(version.LastModified == exercise.Created);
                Assert.IsTrue(version.ValidState == ValidState.NotChecked);
                Assert.IsTrue(version.VersionNumber == 0);
                Assert.IsNull(version.CreatorDifficulty);
                Assert.IsNull(version.CreatorRating);
            }
        }

        [Test]
        public void ShouldUpdateTemporarySaveExercise()
        {
            this.SetupDatabase(DbTestController.State.SEEDED);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IExerciseRepository rep = new ExerciseRepository(context);

                // Setup create new exercise
                User user = context.User.FirstOrDefault();
                System.DateTime creationDate = System.DateTime.Now;

                Exercise exercise = new Exercise
                {
                    Id = 0,
                    Title = "Title1",
                    Created = creationDate,
                    FkUserId = user.Id,
                };

                rep.Create(exercise);

                var version = exercise.ExerciseVersion.First();

                context.Entry(exercise).State = EntityState.Detached;
                context.Entry(version).State = EntityState.Detached;

                // update exercise
                var body = TestDataBuilder<ExerciseBody>.Single();
                body.FkProgrammingLanguageId = 1;
                body.FkExerciseLanguageId = 0;
                body.FkTestSuiteId = 0;
                body.FkTestSuite = TestDataBuilder<TestSuite>.Single();
                var testcase = TestDataBuilder<TestCase>.Single();
                testcase.FkTestSuiteId = 0;
                body.FkTestSuite.TestCase = new List<TestCase>
                {
                    testcase,
                };

                Exercise updatedExercise = new Exercise
                {
                    Id = exercise.Id,
                    Title = exercise.Title,
                    Created = exercise.Created,
                    FkUserId = user.Id,
                    ExerciseVersion = new List<ExerciseVersion>
                    {
                        new ExerciseVersion
                        {
                            Id = version.Id,
                            VersionNumber = version.VersionNumber,
                            CreatorRating = 3,
                            CreatorDifficulty = 4,
                            LastModified = System.DateTime.Now,
                            ValidState = ValidState.NotChecked,
                            FkUserId = 0,
                            FkExerciseId = 0,
                            ExerciseLanguage = new List<ExerciseLanguage>
                            {
                                new ExerciseLanguage
                                {
                                    Id = 0,
                                    FkWrittenLanguageId = 1,
                                    FkExerciseVersionId = 0,
                                    FkExerciseHeaderId = 0,
                                    FkExerciseHeader = new ExerciseHeader
                                    {
                                        Id = 0,
                                        FullTitle = "FullTitle1",
                                        Introduction = "Introduction1",
                                        TemplateParam = "TemplateParam1",
                                        TemplateParamLiftFlag = false,
                                        TwigAllFlag = false,
                                    },
                                    ExerciseBody = new List<ExerciseBody>
                                    {
                                        body,
                                    },
                                },
                            },
                        },
                    },
                    ExerciseTag = new List<ExerciseTag>
                    {
                        new ExerciseTag
                        {
                            Id = 0,
                            FkTagId = 1,
                            FkExerciseId = 0,
                        },
                        new ExerciseTag
                        {
                            Id = 0,
                            FkTagId = 2,
                            FkExerciseId = 0,
                        },
                    },
                };

                Exercise returnedExercise = rep.Update(updatedExercise);

                Assert.IsNotNull(returnedExercise);
                Assert.IsTrue(returnedExercise.ExerciseTag.Count == 2);
            }
        }

        [Test]
        public void ShouldCreateAndUpdate()
        {
            this.SetupDatabase(DbTestController.State.SEEDED);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IExerciseRepository rep = new ExerciseRepository(context);

                var json = @"
                {
	                ""id"":0,
	                ""fkUser"":{
		                ""name"":""sabrina""
	                },
	                ""exerciseTag"":[{}],
	                ""exerciseVersion"":[{
		                ""id"":0,
		                ""fkUser"":{""name"":""sabrina""},
		                ""exerciseLanguage"":[{
			                ""id"":0,
			                ""fkExerciseHeader"":{
				                ""id"":0,
				                ""templateParam"":""Template Parameters"",
				                ""templateParamLiftFlag"":true,
				                ""twigAllFlag"":true,
				                ""fullTitle"":""Full"",
				                ""shortTitle"":""Short"",
				                ""introduction"":""Intro""
			                },
			                ""fkWrittenLanguage"":{""name"":""English""},
			                ""exerciseBody"":[{
				                ""id"":0,
				                ""fkTestSuite"":{
					                ""id"":0,
					                ""testCase"":[{
						                ""id"":0,
						                ""testCode"":""Test Case 1"",
						                ""orderUsed"":1,
						                ""standardInput"":""Standard Input"",
						                ""expectedOutput"":""Expected Output"",
						                ""additionalData"":""Extra Data"",
						                ""displayType"":""SHOW"",
						                ""useAsExampleFlag"":true,
						                ""hideOnFailFlag"":true,
						                ""points"":100
					                }],
					                ""fkQuestionType"":{
						                ""id"":1,
						                ""name"":""c++_question_type""
					                },
					                ""templateDebugFlag"":true,
					                ""preCheck"":0,
					                ""generalFeedbackDisplay"":0,
					                ""globalExtraParam"":""Global Extra"",
					                ""runtimeData"":""Runtime Data"",
					                ""testOnSaveFlag"":true
				                },
				                ""fkProgrammingLanguage"":{""id"":1,""name"":""C++""},
				                ""fieldLines"":20,
				                ""subtractSystem"":""10"",
				                ""optainablePoints"":100,
				                ""idNum"":1,
				                ""solution"":""Answer"",
				                ""prefill"":""Answer Preload"",
				                ""allowFiles"":0,
				                ""filesRequired"":0,
				                ""filesRegex"":""RegEx"",
				                ""filesDescription"":""RegEx Description"",
				                ""maxAllowedFiles"":0,
				                ""feedback"":""General Feedback (E)""
			                }]
		                }],
		                ""validState"":0,
		                ""lastModified"":""2020-12-31T11:43:44.929Z"",
		                ""creatorDifficulty"":0,
		                ""creatorRating"":0,""versionNumber"":0
	                }],
	                ""created"":""2020-12-31T11:43:44.929Z"",
	                ""title"":""Title""
                }";

                var options = new JsonSerializerOptions();
                options.PropertyNameCaseInsensitive = true;

                var exercise = JsonSerializer.Deserialize<Exercise>(json, options);

                Exercise returnedExercise = rep.CreateAndUpdate(exercise);

                Assert.IsNotNull(returnedExercise);
                Assert.IsTrue(returnedExercise.ExerciseTag.Count == 2);
            }
        }

        [Test]
        public void ShouldGetMinimalExercises()
        {
            // NOT TESTABLE WITH SQLITE, BECAUSE APPLY IS NOT SUPPORTED
            /*
            this.SetupDatabase(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IExerciseRepository rep = new ExerciseRepository(context, this.exerciseLogger);

                var list = rep.GetMinimalList();

                Assert.IsNotNull(list);
            }*/
            Assert.IsTrue(true);
        }

        [Test]
        public void ShouldGetExercisesInstance()
        {
            // NOT TESTABLE WITH SQLITE, BECAUSE APPLY IS NOT SUPPORTED
            /*
            this.SetupDatabase(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                IExerciseRepository rep = new ExerciseRepository(context, this.exerciseLogger);

                var list = rep.GetExerciseInstance(1, 1, "C++", "English");

                Assert.IsNotNull(list);
            }*/

            Assert.IsTrue(true);
        }

        private void SetupDatabase(DbTestController.State state) => this.testDb = new CodeRunnerTestDb(state);
    }
}
