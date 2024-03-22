using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Administrator : Member
    {
        private string _phoneNumber;

        public Administrator(string Email, string Password, string PhoneNumber) : base(Email, Password) 
        { 
            this._phoneNumber = PhoneNumber;
        }

        public override string ToString()
        {
            return _phoneNumber;
        }
    }
}
