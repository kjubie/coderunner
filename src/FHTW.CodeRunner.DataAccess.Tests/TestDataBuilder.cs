// <copyright file="TestDataBuilder.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
using FHTW.CodeRunner.DataAccess.Entities;
using FizzWare.NBuilder;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    /// <summary>
    /// Utility functions that help creating entities for testing.
    /// </summary>
    public class TestDataBuilder
    {
        static TestDataBuilder()
        {
            BuilderSetup.DisablePropertyNamingFor<Benutzer, int>(x => x.Id);
        }

        /// <summary>
        /// Create a new users with generated data.
        /// </summary>
        /// <returns>new user.</returns>
        public static Benutzer Benutzer()
        {
            return Builder<Benutzer>.CreateNew().Build();
        }

        /// <summary>
        /// Create a list of new users with generated data.
        /// </summary>
        /// <param name="amount">the amount of users generated.</param>
        /// <returns>list of new users.</returns>
        public static IList<Benutzer> ManyBenutzer(int amount)
        {
            Debug.Assert(amount > 1, "use Benutzer() for creating one User");
            return Builder<Benutzer>.CreateListOfSize(amount).Build();
        }
    }
}
