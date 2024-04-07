using Database;
using DatabaseAccess;
using Entity_Layer;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class PeopleManager
    {
        public List<Person> people { get; set; }
        private DataAccess access;
        private DataWriter writer;
        private DataRemover remover;

        public PeopleManager()
        {
            people = new List<Person>();
            access = new DataAccess();
            writer = new DataWriter();
            remover = new DataRemover();
        }

        public void AddUser(User user)
        {
            writer.AddUser(user.Username, user.email, user.password, user._licenseNumber, user.CreatedOn);
            people.Add(user);
        }

        public void AddAdmin(Administrator admin)
        {
            writer.AddAdmin(admin.Username, admin.email, admin.password, admin._phoneNumber, admin.CreatedOn);
            people.Add(admin);
        }
    }
}
