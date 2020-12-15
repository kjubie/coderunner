using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    ///
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class Error
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        [Required]
        [DataMember(Name = "errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
