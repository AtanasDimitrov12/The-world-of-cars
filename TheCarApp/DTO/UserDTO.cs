﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string passSalt { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }
        public int _licenseNumber { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}
