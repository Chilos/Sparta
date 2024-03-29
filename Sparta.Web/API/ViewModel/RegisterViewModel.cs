﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Sparta.Web.API.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
