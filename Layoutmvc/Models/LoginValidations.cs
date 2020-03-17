﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAYOUTSMVC.Models
{
    public class LoginValidations
    {
        string login;
        string password;
        [Required(ErrorMessage ="Username is required")]
        public string Login { get => login; set => login = value; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get => password; set => password = value; }
    }
}