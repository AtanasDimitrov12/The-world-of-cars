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

        string AddPerson(Person person);
        (string Hash, string Salt) HashPassword(string password);
        string RemovePerson(Person person);
        string UpdatePerson(Person person);
        bool AuthenticateUser(string Email, string Password);
        bool VerifyPassword(string enteredPassword, string storedPass, string base64Salt);
        User GetUser(string Email);
        IEnumerable<Person> GetAllPeople();
    }
}
