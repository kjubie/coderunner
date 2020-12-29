// <copyright file="SimpleRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// The default implementation of the <see cref="ISimpleRepository{TEntity}"/> interface.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity.</typeparam>
    /// <typeparam name="TContext">Type of the context.</typeparam>
    public class SimpleRepository<TEntity, TContext> : ISimpleRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        private readonly TContext context = null;
        private readonly DbSet<TEntity> table = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleRepository{TEntity, TContext}"/> class.
        /// automatically creates an instance of the <see cref="TContext"/> type.
        /// it is generally recommended to inject the context by using the <see cref="SimpleRepository{TEntity, TContext}.SimpleRepository(TContext)"/>constructor.
        /// </summary>
        [Obsolete]
        public SimpleRepository()
        {
            this.context = new TContext();
            this.table = this.context.Set<TEntity>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleRepository{TEntity, TContext}"/> class.
        /// </summary>
        /// <param name="context">The context to be injected.</param>
        public SimpleRepository(TContext context)
        {
            this.context = context;
            this.table = this.context.Set<TEntity>();
        }

        /// <summary>
        /// Gets the context to the child class.
        /// </summary>
        protected TContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <inheritdoc/>
        public virtual void Delete(TEntity entity)
        {
            this.table.Attach(entity);
            this.table.Remove(entity);
            this.Save();
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.table;
        }

        /// <inheritdoc/>
        public virtual TEntity GetById(int id)
        {
            return this.table.Find(id);
        }

        /// <inheritdoc/>
        public virtual void Insert(TEntity entity)
        {
            this.table.Add(entity);
            this.Save();
        }

        /// <inheritdoc/>
        public void Save()
        {
            this.context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual void Update(TEntity entity)
        {
            this.table.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
            this.Save();
        }

        /// <inheritdoc/>
        public bool Exists(TEntity entity)
        {
            return this.table.Any(e => e == entity);
        }
    }
}
