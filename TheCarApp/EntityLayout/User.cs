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

        public User(int Id, string Email, string Password, string UserName, DateTime CreatedON, int License, string passSalt) : base(Id, Email, Password, UserName, CreatedON, passSalt)
        {
            this.LicenseNumber = License;
        }

        public override string ToString()
        {
            return LicenseNumber.ToString();
        }
    }
}
