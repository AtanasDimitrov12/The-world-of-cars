using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public abstract class Member
    {
        private string email { get; set; }
        private string password { get; set; }

        public Member (string name, string password)
        {
            this.email = name;
            this.password = password;
        }

        public abstract string ToString();
    }
}
