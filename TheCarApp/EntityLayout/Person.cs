 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }

        public Person (int Id, string name, string password, string username, DateTime createdOn)
        {
            this.Id = Id;
            this.email = name;
            this.password = password;
            this.Username = username;
            this.CreatedOn = createdOn;
        }

        public abstract string ToString();
    }
}
