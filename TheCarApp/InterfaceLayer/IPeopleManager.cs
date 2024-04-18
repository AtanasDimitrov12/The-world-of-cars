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

        void AddPerson(Person person);
        void RemovePerson(Person person);
        void UpdatePerson(Person person);
        bool AuthenticateUser(User checkUser);
        User GetUser(string Email);
        IEnumerable<Person> GetAllPeople();
        void LoadPeopleFromDB();
    }
}
