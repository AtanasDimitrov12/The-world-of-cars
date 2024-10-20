﻿using Database;
using DatabaseAccess;
using Entity_Layer;
using InterfaceLayer;
using Manager_Layer;
using ManagerLayer.Strategy;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer
{
    public class ProjectManager
    {
        public ICarManager CarManager { get; set; }
        public INewsManager NewsManager { get; set; }
        public ICommentsManager CommentsManager { get; set; }
        public IRentManager RentManager { get; set; }
        public IPeopleManager PeopleManager { get; set; }
        public IExtraManager ExtraManager { get; set; }
        public IPictureManager PictureManager { get; set; }
        public IUserRepository UserRepository { get; set; }
        public IAdministratorRepository AdministratorRepository { get; set; }
        public IDataAccess DataAccess { get; set; }
        public IPeopleDataWriter PeopleDataWriter { get; set; }
        public ICarDataWriter CarDataWriter { get; set; }
        public ICarNewsDataWriter CarNewsDataWriter { get; set; }
        public ICarDataRemover CarDataRemover { get; set; }
        public ICarNewsDataRemover CarNewsDataRemover { get; set; }
        public IPeopleDataRemover PeopleDataRemover { get; set; }
        public IRentalStrategyFactory rentalStrategyFactory { get; set; }

        public ProjectManager()
        {
            DataAccess = new DataAccess();
            PeopleDataWriter = new PeopleDataWriter();
            CarDataWriter = new CarDataWriter();
            CarNewsDataWriter = new CarNewsDataWriter();
            CarDataRemover = new CarDataRemover();
            CarNewsDataRemover = new CarNewsDataRemover();
            PeopleDataRemover = new PeopleDataRemover();
            rentalStrategyFactory = new RentalStrategyFactory();
            CarManager = new CarManager(DataAccess, CarDataWriter, CarDataRemover);
            NewsManager = new NewsManager(DataAccess, CarNewsDataWriter, CarNewsDataRemover);
            CommentsManager = new CommentsManager(DataAccess, CarNewsDataWriter, CarNewsDataRemover);
            ExtraManager = new ExtraManager(DataAccess, CarDataWriter, CarDataRemover);
            PictureManager = new PictureManager(DataAccess, CarDataWriter, CarDataRemover);
            UserRepository = new UserRepository(DataAccess, PeopleDataWriter, PeopleDataRemover);
            AdministratorRepository = new AdministratorRepository(DataAccess, PeopleDataWriter, PeopleDataRemover);
            PeopleManager = new PeopleManager(UserRepository, AdministratorRepository);
            RentManager = new RentManager(DataAccess, PeopleDataWriter, PeopleDataRemover, PeopleManager, CarManager, rentalStrategyFactory);
            LoadAllData();
        }

        public void LoadAllData()
        { 
            CarManager.LoadCars(out string CarerrorMessage);
            NewsManager.LoadNews(out string NewsErrorMessage);
            UserRepository.LoadUsers(out string UserErrorMessage);
            AdministratorRepository.LoadAdmins(out string AdminErrorMessage);
            RentManager.LoadRentals(out string RentsErrorMessage);
        }
    }
}