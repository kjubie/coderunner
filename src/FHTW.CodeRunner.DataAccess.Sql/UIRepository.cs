// <copyright file="UIRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.DataAccess.Sql
{
    /// <summary>
    /// The repository that holds information for the UI.
    /// </summary>
    public class UIRepository : IUIRepository
    {
        private readonly CodeRunnerContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UIRepository(CodeRunnerContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public List<ProgrammingLanguage> GetProgrammingLanguages()
        {
            try
            {
                return this.context.ProgrammingLanguage.ToList();
            }
            catch (Exception e)
            {
                throw new DalException(e.Message, e);
            }
        }

        /// <inheritdoc/>
        public List<WrittenLanguage> GetWrittenLanguages()
        {
            try
            {
                return this.context.WrittenLanguage.ToList();
            }
            catch (Exception e)
            {
                throw new DalException(e.Message, e);
            }
        }

        /// <inheritdoc/>
        public List<QuestionType> GetQuestionTypes()
        {
            try
            {
                return this.context.QuestionType.ToList();
            }
            catch (Exception e)
            {
                throw new DalException(e.Message, e);
            }
        }
    }
}
