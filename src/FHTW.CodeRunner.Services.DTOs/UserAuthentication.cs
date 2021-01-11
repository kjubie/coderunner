// <copyright file="UserAuthentication.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    /// <summary>
    /// Entity that describes the authentication for user.
    /// </summary>
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class UserAuthentication
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
