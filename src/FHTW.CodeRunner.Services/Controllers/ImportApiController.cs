// <copyright file="ImportApiController.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FHTW.CodeRunner.Services.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class ImportApiController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private readonly IImportLogic importLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportApiController"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="importLogic"></param>
        public ImportApiController(ILogger<ImportApiController> logger, IMapper mapper, IImportLogic importLogic)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.importLogic = importLogic;
        }

        [HttpPost]
        [Route("import/collection")]
        public virtual IActionResult ImportCollection()
        {
            return this.Ok();
        }
    }
}
