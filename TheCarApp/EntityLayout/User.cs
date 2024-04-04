using EntityLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class User : Member
    {
        public string _licenseNumber { get; set; }

        public User(string Email, string Password, string UserName, DateTime CreatedON, string License) : base(Email, Password, UserName, CreatedON)
        {
            this._licenseNumber = License; 
        }

        public override string ToString()
        {
            return _licenseNumber;
        }
    }
}
