﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistrationSys.Models.ViewModels
{
    public class ResetPassword
    {
        public string StudentId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
