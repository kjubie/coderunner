using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that returns the user id after a successful authentication.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class AuthenticateOk
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}
