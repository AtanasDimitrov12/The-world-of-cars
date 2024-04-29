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
        string RemovePerson(Person person);
        string UpdatePerson(Person person);
        bool AuthenticateUser(string Email, string Password);
        User GetUser(string Email);
        IEnumerable<Person> GetAllPeople();
    }
}
