// <copyright file="DbSetExtenstion.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// Exteneion for Dbset.
    /// </summary>
    public static class DbSetExtenstion
    {
        /// <summary>
        /// Get the table name form dbset.
        /// </summary>
        /// <typeparam name="T">EntityType.</typeparam>
        /// <param name="dbSet">DbSet.</param>
        /// <param name="dbContext">Context.</param>
        /// <returns>table name.</returns>
        public static string GetTableName<T>(this DbSet<T> dbSet, CodeRunnerContext dbContext)
            where T : class
        {
            var model = dbContext.Model;
            var entityTypes = model.GetEntityTypes();
            var entityType = entityTypes.First(t => t.ClrType == typeof(T));
            var tableNameAnnotation = entityType.GetAnnotation("Relational:TableName");
            var tableName = tableNameAnnotation.Value.ToString();
            return tableName;
        }
    }
}
