using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace FHTW.CodeRunner.Services.DTOs
{
    public class UserAuthentication
    {
        [Required]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [Required]
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
