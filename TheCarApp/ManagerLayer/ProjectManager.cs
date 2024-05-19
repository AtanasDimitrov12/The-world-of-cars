using Database;
using DatabaseAccess;
using Entity_Layer;
using InterfaceLayer;
using Manager_Layer;
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

        public ProjectManager()
        {
            DataAccess = new DataAccess();
            PeopleDataWriter = new PeopleDataWriter();
            CarDataWriter = new CarDataWriter();
            CarNewsDataWriter = new CarNewsDataWriter();
            CarDataRemover = new CarDataRemover();
            CarNewsDataRemover = new CarNewsDataRemover();
            PeopleDataRemover = new PeopleDataRemover();
            CarManager = new CarManager(DataAccess, CarDataWriter, CarDataRemover);
            NewsManager = new NewsManager(DataAccess, CarNewsDataWriter, CarNewsDataRemover);
            CommentsManager = new CommentsManager(DataAccess, CarNewsDataWriter, CarNewsDataRemover);
            RentManager = new RentManager(DataAccess, PeopleDataWriter, PeopleDataRemover);  
            ExtraManager = new ExtraManager(DataAccess, CarDataWriter, CarDataRemover);
            PictureManager = new PictureManager(DataAccess, CarDataWriter, CarDataRemover);
            UserRepository = new UserRepository(DataAccess, PeopleDataWriter, PeopleDataRemover);
            AdministratorRepository = new AdministratorRepository(DataAccess, PeopleDataWriter, PeopleDataRemover);
            PeopleManager = new PeopleManager(UserRepository, AdministratorRepository);
            LoadAllData();
        }

        public void LoadAllData()
        { 
            CarManager.LoadCars();
            NewsManager.LoadNews();
            RentManager.LoadRentals();
            UserRepository.LoadUsers();
            AdministratorRepository.LoadAdmins();
        }
    }
}