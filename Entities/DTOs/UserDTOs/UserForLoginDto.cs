﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.UserDTOs
{
    public class UserForLoginDto: IDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
