﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class Admin
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
