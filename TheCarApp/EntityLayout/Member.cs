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
        private string Username { get; set; }
        private DateTime CreatedOn { get; set; }

        public Member (string name, string password, string username, DateTime createdOn)
        {
            this.email = name;
            this.password = password;
            this.Username = username;
            this.CreatedOn = createdOn;
        }

        public abstract string ToString();
    }
}
