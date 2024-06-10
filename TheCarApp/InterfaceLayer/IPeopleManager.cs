using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPeopleManager
    {
        List<Person> people { get; set; }

        bool AddPerson(Person person, out string errorMessage);
        bool RemovePerson(Person person, out string errorMessage);
        bool UpdatePerson(Person person, out string errorMessage);
        bool AuthenticateUser(string userEmail, string userPass, out string errorMessage);
        public (string Hash, string Salt) HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedPass, string base64Salt);
        User GetUser(string email);
        IEnumerable<Person> GetAllPeople();
        List<User> GetAllUsers();
    }
}
