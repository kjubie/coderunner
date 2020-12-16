// <copyright file="IUIRepository.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using FHTW.CodeRunner.DataAccess.Entities;

namespace FHTW.CodeRunner.DataAccess.Interfaces
{
    /// <summary>
    /// The Interface for the UIRepository class.
    /// </summary>
    public interface IUIRepository
    {
        /// <summary>
        /// Gets a list with all progrmming languages.
        /// </summary>
        /// <returns>returns a list containing all programming languages.</returns>
        List<ProgrammingLanguage> GetProgrammingLanguages();

        /// <summary>
        /// Gets a list with all written languages.
        /// </summary>
        /// <returns>returns a list containing all written languages.</returns>
        List<WrittenLanguage> GetWrittenLanguages();

        /// <summary>
        /// Gets a list with all questiontypes.
        /// </summary>
        /// <returns>returns a list containing all questiontypes.</returns>
        List<QuestionType> GetQuestionTypes();
    }
}
