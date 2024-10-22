﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asmaa.DAL.Model
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}