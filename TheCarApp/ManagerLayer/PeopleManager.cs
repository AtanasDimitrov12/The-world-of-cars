using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
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

        public void RemoveUser(User user)
        {
            remover.RemoveUser(user.Id);
            people.Remove(user);
        }

        public void RemoveAdmin(Administrator admin)
        {
            remover.RemoveAdmin(admin.Id);
            people.Remove(admin);
        }

        public void UpdateAdmin(Administrator admin)
        {
            writer.UpdateAdministration(admin.Id, admin.Username, admin.email, admin.password, admin._phoneNumber, admin.CreatedOn);
        }


        public void LoadPeople()
        {
            if (access.GetUsers() != null && access.GetAdministrators() != null)
            {
                foreach (UserDTO userDTO in access.GetUsers())
                {
                    User user = new User(userDTO.Id, userDTO.email, userDTO.password, userDTO.Username, userDTO.CreatedOn, userDTO._licenseNumber);
                    people.Add(user);
                }

                foreach (AdministratorDTO adminDTO in access.GetAdministrators())
                {
                    Administrator admin = new Administrator(adminDTO.Id, adminDTO.email, adminDTO.password, adminDTO.Username, adminDTO.CreatedOn, adminDTO._phoneNumber);
                    people.Add(admin);
                }
            }
        }
    }
}
