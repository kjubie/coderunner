﻿// <copyright file="ExportLogic.cs" company="FHTW CodeRunner">
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
    public class ExportLogic : IExportLogic
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IMoodleXmlService moodleXmlService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportLogic"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="moodleXmlService"></param>
        public ExportLogic(ILogger<ExportLogic> logger, IMapper mapper, IMoodleXmlService moodleXmlService)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.moodleXmlService = moodleXmlService;
        }

        public void ExportCollection(Collection collection)
        {
            throw new NotImplementedException();
        }

        public void ExportExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }
    }
}