using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Member
    {
        private string name { get; set; }
        private string password { get; set; }

        public Member (string name, string password)
        {
            this.name = name;
            this.password = password;
        }
    }
}
