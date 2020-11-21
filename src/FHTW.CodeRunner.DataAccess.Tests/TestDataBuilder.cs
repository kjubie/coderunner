// <copyright file="TestDataBuilder.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FizzWare.NBuilder;

namespace FHTW.CodeRunner.DataAccess.Tests
{
    /// <summary>
    /// Utility functions that help creating entities for testing.
    /// </summary>
    public class TestDataBuilder<TEntity>
        where TEntity : IEntity
    {
        static TestDataBuilder()
        {
            PropertyInfo info = typeof(TEntity).GetType().GetProperty("Id");
            BuilderSetup.DisablePropertyNamingFor<TEntity, int>(x => x.Id);
        }

        /// <summary>
        /// Create a new users with generated data.
        /// Will always generate the entity with the same data.
        /// Example: Name Property will be named Name1.
        /// </summary>
        /// <returns>new user.</returns>
        public static TEntity Single()
        {
            return Builder<TEntity>.CreateNew().Build();
        }

        /// <summary>
        /// Create a list of new users with generated data.
        /// Property values will be generated the same way as in Single() method, but will be automatically incremented.
        /// Name = Name1.
        /// Name = Name2.
        /// ...
        /// </summary>
        /// <param name="amount">the amount of users generated.</param>
        /// <returns>list of new users.</returns>
        public static IList<TEntity> Many(int amount)
        {
            Debug.Assert(amount > 1, "use Single() for creating one entity");
            return Builder<TEntity>.CreateListOfSize(amount).Build();
        }
    }
}
