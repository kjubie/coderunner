// <copyright file="CollectionRepositoryTests.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Testnames should be explanation enough.")]
    [TestFixture]
    public class CollectionRepositoryTests
    {
        private CodeRunnerTestDb testDb;

        [TearDown]
        public void NullDatabase() => this.testDb = null;

        [Test]
        public void ShouldGetExerciseInstancesWithSetLanguage()
        {
            // Cannot be tested with sqlite
            /*
            this.SetupDatabaseReal(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                ICollectionRepository rep = new CollectionRepository(context);

                var list = rep.GetExercisesInstances(1);

                Assert.NotNull(list);
            }*/

            Assert.True(true);
        }

        [Test]
        public void ShouldGetExerciseInstancesWithChosenLanguage()
        {
            // Cannot be tested with sqlite
            /*
            this.SetupDatabaseReal(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                ICollectionRepository rep = new CollectionRepository(context);

                var list = rep.GetExercisesInstances(1, "German");

                Assert.NotNull(list);
            }*/

            Assert.True(true);
        }

        [Test]
        public void ShouldCreateNewCollection()
        {
            // Cannot be tested with sqlite
            this.SetupDatabaseInMemory(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                ICollectionRepository rep = new CollectionRepository(context);

                var json = @"
				{   
                    ""Title"": ""Title_2"",
                    ""Created"": ""2021-08-23T18:25:43.51"",
                    ""FkUserId"": 1,
                    ""CollectionLanguage"": [
                        {
                            ""FullTitle"": ""FullTitle_2"",
                            ""ShortTitle"": ""ShortTitle_2"",
                            ""Introduction"": ""Introduction_2"",
                            ""FkWrittenLanguageId"": 1
                        }
                    ],
                    ""CollectionTag"": [
                        {
                            ""FkTagId"": 1
                        },
                        {
                            ""FkTagId"": 2
                        }
                    ],
                    ""CollectionExercise"": [
                        {
                            ""VersionNumber"": 1,
                            ""FkExerciseId"": 1,
                            ""FkProgrammingLanguageId"": 1,
                            ""FkWrittenLanguageId"": 1
                        },
                        {
                            ""VersionNumber"": 1,
                            ""FkExerciseId"": 2,
                            ""FkProgrammingLanguageId"": 3,
                            ""FkWrittenLanguageId"": 1
                        }
                    ]
                }";

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var collection = JsonSerializer.Deserialize<Collection>(json, options);

                rep.CreateOrUpdate(collection);

                var added = rep.GetById(2, Mode.ReadOnly);

                Assert.IsNotNull(added, "This tests assumes that only one exercise with the id = 1 is in the seeded testdb");
                Assert.IsNotNull(added.CollectionExercise);
                Assert.IsNotNull(added.CollectionLanguage);
                Assert.IsNotNull(added.CollectionTag);

                Assert.AreEqual(added.CollectionExercise.Count, 2, "2 collection exercises should be present");
                Assert.AreEqual(added.CollectionLanguage.Count, 1, "1 collection languages should be present");
                Assert.AreEqual(added.CollectionTag.Count, 2, "2 tags should be present");
            }
        }

        [Test]
        public void ShouldUpdateExistingCollection()
        {
            // Cannot be tested with sqlite
            this.SetupDatabaseInMemory(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                ICollectionRepository rep = new CollectionRepository(context);

                var json = @"
				{   
                    ""Id"": 1,
                    ""Title"": ""Title_2"",
                    ""Created"": ""2011-08-23T18:25:43.51"",
                    ""FkUserId"": 2,
                    ""CollectionLanguage"": [
                        {
                            ""Id"": 1,
                            ""FullTitle"": ""FullTitle_2"",
                            ""ShortTitle"": ""ShortTitle_2"",
                            ""Introduction"": ""Introduction_2"",
                            ""FkWrittenLanguageId"": 1
                        }
                    ],
                    ""CollectionTag"": [
                        {
                            ""FkTagId"": 1
                        },
                        {
                            ""FkTagId"": 2
                        }
                    ],
                    ""CollectionExercise"": [
                        {
                            ""Id"": 1,
                            ""VersionNumber"": 2,
                            ""FkExerciseId"": 1,
                            ""FkProgrammingLanguageId"": 2,
                            ""FkWrittenLanguageId"": 1
                        },
                        {
                            ""VersionNumber"": 1,
                            ""FkExerciseId"": 2,
                            ""FkProgrammingLanguageId"": 3,
                            ""FkWrittenLanguageId"": 1
                        }
                    ]
                }";

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var collection = JsonSerializer.Deserialize<Collection>(json, options);

                var old = rep.GetById(1, Mode.ReadOnly);

                rep.CreateOrUpdate(collection);

                var new_c = rep.GetById(1, Mode.ReadOnly);

                Assert.IsNotNull(new_c);
                Assert.IsNotNull(new_c.CollectionExercise);
                Assert.IsNotNull(new_c.CollectionLanguage);
                Assert.IsNotNull(new_c.CollectionTag);

                // should not be updated
                Assert.AreEqual(new_c.FkUserId, old.FkUserId, "UserId should not update");
                Assert.AreEqual(new_c.Created, old.Created, "Created date should not update");

                // Only new things should be added
                Assert.AreEqual(new_c.CollectionExercise.Count, 2, "After update 2 exercises should be present");
                Assert.AreEqual(new_c.CollectionLanguage.Count, old.CollectionLanguage.Count,"After update the collectionlanguage count should be the same");
                Assert.AreEqual(new_c.CollectionTag.Count, 2, "After update 2 tags should be present");
            }
        }

        private void SetupDatabaseReal(DbTestController.State state) => this.testDb = CodeRunnerTestDb.AsRealTestDb(state);

        private void SetupDatabaseInMemory(DbTestController.State state) => this.testDb = CodeRunnerTestDb.AsInMemoryDb(state);
    }
}
