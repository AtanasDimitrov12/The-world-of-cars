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
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassSalt { get; set; }
        public string Username { get; set; } 
        public DateTime CreatedOn { get; set; }

        public Person (int Id, string name, string password, string username, DateTime createdOn, string passSalt)
        {
            this.Id = Id;
            this.Email = name;
            this.Password = password;
            this.Username = username;
            this.CreatedOn = createdOn;
            this.PassSalt = passSalt;
        }

        public Person()
        { 
        
        }

        public abstract string ToString();
    }
}
