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
        private readonly ILogger<UIRepository> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="logger">The logger.</param>
        public UIRepository(CodeRunnerContext context, ILogger<UIRepository> logger)
        {
            this.context = context;
            this.logger = logger;
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
                this.logger.LogError("Error in GetProgrammingLanguages()", e);
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
                this.logger.LogError("Error in GetWrittenLanguages()", e);
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
                this.logger.LogError("Error in QuestionType()", e);
                throw new DalException(e.Message, e);
            }
        }
    }
}
