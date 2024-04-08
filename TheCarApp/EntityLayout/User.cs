using EntityLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class User : Person
    {
        public int _licenseNumber { get; set; }

        public User(int Id, string Email, string Password, string UserName, DateTime CreatedON, int License) : base(Id, Email, Password, UserName, CreatedON)
        {
            this._licenseNumber = License; 
        }

        public override string ToString()
        {
            return _licenseNumber.ToString();
        }
    }
}
