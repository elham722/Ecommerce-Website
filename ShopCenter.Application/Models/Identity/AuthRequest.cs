﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Models.Identity
{
    public class AuthRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
