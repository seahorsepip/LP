﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace La_Crosta_Insapore.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}