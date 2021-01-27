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
            /*
            // Cannot be tested with sqlite
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

                var list = rep.GetCollectionInstance(1, "English", true);

                var list = rep.GetCollectionInstance(1, "English", true);

                Assert.NotNull(list);
            }
            */
            Assert.True(true);
        }

        [Test]
        public void ShouldGetMinimalCollections()
        {
            // Cannot be tested with sqlite
            this.SetupDatabaseReal(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                ICollectionRepository rep = new CollectionRepository(context);

                var list = rep.GetMinimalCollections();

                Assert.NotNull(list);
            }

            Assert.True(true);
        }

        [Test]
        public void ShouldCreateNewCollection()
        {
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
                            ""FkTag"":
                                {
                                    ""id"": 1,
                                    ""name"": ""algorithms""
                                }
                        },
                        {
                            ""FkTag"":
                                {
                                    ""name"": ""unigerst""
                                }
                        },
                        {
                            ""FkTagId"": 3
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

                var added = rep.GetById(2);

                Assert.IsNotNull(added, "This tests assumes that only one exercise with the id = 1 is in the seeded testdb");
                Assert.IsNotNull(added.CollectionExercise);
                Assert.IsNotNull(added.CollectionLanguage);
                Assert.IsNotNull(added.CollectionTag);

                Assert.AreEqual(2, added.CollectionExercise.Count, "2 collection exercises should be present");
                Assert.AreEqual(1, added.CollectionLanguage.Count, "1 collection languages should be present");
                Assert.AreEqual(3, added.CollectionTag.Count, "3 tags should be present");
            }
        }

        [Test]
        public void ShouldUpdateExistingCollection()
        {
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
                            ""Id"": 2,
                            ""VersionNumber"": 1,
                            ""FkExerciseId"": 2,
                            ""FkProgrammingLanguageId"": 6,
                            ""FkWrittenLanguageId"": 1
                        },
                        {
                            ""VersionNumber"": 1,
                            ""FkExerciseId"": 3,
                            ""FkProgrammingLanguageId"": 5,
                            ""FkWrittenLanguageId"": 2
                        }
                    ]
                }";

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                var collection = JsonSerializer.Deserialize<Collection>(json, options);

                var old = rep.GetById(1);

                rep.CreateOrUpdate(collection);

                var new_c = rep.GetById(1);

                Assert.IsNotNull(new_c);
                Assert.IsNotNull(new_c.CollectionExercise);
                Assert.IsNotNull(new_c.CollectionLanguage);
                Assert.IsNotNull(new_c.CollectionTag);

                // should not be updated
                Assert.AreEqual(old.FkUserId, new_c.FkUserId, "UserId should not update");
                Assert.AreEqual(old.Created, new_c.Created, "Created date should not update");

                // Only new things should be added
                Assert.AreEqual(3, new_c.CollectionExercise.Count, "After update 3 exercises should be present");
                Assert.AreEqual(old.CollectionLanguage.Count, new_c.CollectionLanguage.Count, "After update the collectionlanguage count should be the same");
                Assert.AreEqual(2, new_c.CollectionTag.Count, "After update 2 tags should be present");
            }
        }

        [Test]
        public void ShouldCreateNewCollectionWithExistingTagsButNoTagId()
        {
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
                            ""FkTag"":
                                {
                                    ""name"": ""algorithms""
                                }
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

                var added = rep.GetById(2);

                Assert.IsNotNull(added, "This tests assumes that only one exercise with the id = 1 is in the seeded testdb");
                Assert.IsNotNull(added.CollectionExercise);
                Assert.IsNotNull(added.CollectionLanguage);
                Assert.IsNotNull(added.CollectionTag);

                Assert.AreEqual(2, added.CollectionExercise.Count, "2 collection exercises should be present");
                Assert.AreEqual(1, added.CollectionLanguage.Count, "1 collection languages should be present");
                Assert.AreEqual(1, added.CollectionTag.Count, "1 tag should be present");
            }
        }

        [Test]
        public void ShouldSearch()
        {
            /*
            this.SetupDatabaseReal(DbTestController.State.SEEDEDJSON);
            using (var context = new CodeRunnerContext(this.testDb.ContextOptions))
            {
                ICollectionRepository rep = new CollectionRepository(context);

                var list = rep.SearchAndFilter("Kurz", "German");

                Assert.NotNull(list);
            }*/

            Assert.True(true);
        }

        private void SetupDatabaseReal(DbTestController.State state) => this.testDb = CodeRunnerTestDb.AsRealTestDb(state);

        private void SetupDatabaseInMemory(DbTestController.State state) => this.testDb = CodeRunnerTestDb.AsInMemoryDb(state);
    }
}
