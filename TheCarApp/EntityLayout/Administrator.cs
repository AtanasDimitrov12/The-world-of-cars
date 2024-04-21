using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Administrator : Person
    {
        public string _phoneNumber { get; set; }

        public Administrator(int Id, string Email, string Password, string UserName, DateTime CreatedON, string PhoneNumber, byte[] passSalt) : base(Id, Email, Password, UserName, CreatedON, passSalt) 
        { 
            this._phoneNumber = PhoneNumber;
        }

        public override string ToString()
        {
            return _phoneNumber;
        }
    }
}
