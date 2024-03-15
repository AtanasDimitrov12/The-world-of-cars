using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class User : Member
    {
        private string _userName;

        public User(string Email, string Password, string UserName) : base(Email, Password)
        {
            this._userName = UserName;
        }

        public override string ToString()
        {
            return _userName;
        }
    }
}
