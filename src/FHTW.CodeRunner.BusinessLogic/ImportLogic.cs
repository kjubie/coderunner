// <copyright file="ImportLogic.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Entities;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.ExportService.Interfaces;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.BusinessLogic
{
    /// <summary>
    /// Logic Class for import actions.
    /// </summary>
    public class ImportLogic : IImportLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IMoodleXmlService moodleXmlService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportLogic"/> class.
        /// </summary>
        /// <param name="logger">The injected logger.</param>
        /// <param name="mapper">The injected mapper.</param>
        /// <param name="moodleXmlService">The injected moodle xml service.</param>
        public ImportLogic(ILogger<ImportLogic> logger, IMapper mapper, IMoodleXmlService moodleXmlService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.moodleXmlService = moodleXmlService;
        }

        /// <inheritdoc/>
        public Collection ImportCollection()
        {
            throw new NotImplementedException();
        }
    }
}
