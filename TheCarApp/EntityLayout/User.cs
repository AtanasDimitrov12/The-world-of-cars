using EntityLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class User : Person
    {
        public int LicenseNumber { get; set; }
        public string ProfilePicturePath { get; set; }

        public User(int Id, string Email, string Password, string UserName, DateTime CreatedON, int License, string passSalt, string profilePicturePath) : base(Id, Email, Password, UserName, CreatedON, passSalt)
        {
            this.LicenseNumber = License;
            ProfilePicturePath = profilePicturePath;
        }

        public override string ToString()
        {
            return LicenseNumber.ToString();
        }
    }
}
