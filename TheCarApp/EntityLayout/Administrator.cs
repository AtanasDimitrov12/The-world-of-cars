using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Administrator : Member
    {
        private string _phoneNumber { get; set; }

        public Administrator(string Email, string Password, string UserName, DateTime CreatedON, string PhoneNumber) : base(Email, Password, UserName, CreatedON) 
        { 
            this._phoneNumber = PhoneNumber;
        }

        public override string ToString()
        {
            return _phoneNumber;
        }
    }
}
