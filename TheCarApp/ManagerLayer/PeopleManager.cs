﻿using Database;
using DatabaseAccess;
using DTO;
using Entity_Layer;
using Entity_Layer.Enums;
using EntityLayout;
using InterfaceLayer;
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
        private IUserRepository _userRepository;
        private IAdministratorRepository _administratorRepository;

        public PeopleManager(IUserRepository userRepository, IAdministratorRepository administratorRepository)
        {
            _userRepository = userRepository;
            _administratorRepository = administratorRepository;
        }

        public void AddPerson(Person person)
        {
            switch (person)
            {
                case User user:
                    _userRepository.AddUser(user);
                    break;
                case Administrator admin:
                    _administratorRepository.AddAdmin(admin);
                    break;
                default:
                    throw new ArgumentException("Unsupported person type");
            }
        }

        public void RemovePerson(Person person)
        {
            switch (person)
            {
                case User user:
                    _userRepository.RemoveUser(user.Id);
                    break;
                case Administrator admin:
                    _administratorRepository.RemoveAdmin(admin);
                    break;
                default:
                    throw new ArgumentException("Unsupported person type");
            }
        }

        public void UpdatePerson(Person person)
        {
            switch (person)
            {
                case User user:
                    _userRepository.UpdateUser(user);
                    break;
                case Administrator admin:
                    _administratorRepository.UpdateAdmin(admin);
                    break;
                default:
                    throw new ArgumentException("Unsupported person type");
            }
        }

        public IEnumerable<Person> LoadPeople()
        {
            var users = _userRepository.GetAllUsers();
            var admins = _administratorRepository.GetAllAdministrators();

            return users.Cast<Person>().Concat(admins);
        }

        public void LoadPeopleFromDB() // trqbva da go prehvurlq kum suotvetnite classove
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
