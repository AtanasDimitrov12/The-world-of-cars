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
        public ICarManager carManager { get; set; }
        public INewsManager newsManager { get; set; }
        public ICommentsManager commentsManager { get; set; }
        public IRentManager rentManager { get; set; }
        public IPeopleManager peopleManager { get; set; }
        public IExtraManager extraManager { get; set; }
        public IPictureManager pictureManager { get; set; }
        public IUserRepository userRepository { get; set; }
        public IAdministratorRepository administratorRepository { get; set; }
        IDataAccess dataAccess { get; set; }
        IDataWriter dataWriter { get; set; }
        IDataRemover dataRemover { get; set; }

        public ProjectManager()
        {
            dataAccess = new DataAccess();
            dataWriter = new DataWriter();
            dataRemover = new DataRemover();
            carManager = new CarManager(dataAccess, dataWriter, dataRemover);
            newsManager = new NewsManager(dataAccess, dataWriter, dataRemover);
            commentsManager = new CommentsManager(dataAccess, dataWriter, dataRemover);
            rentManager = new RentManager();  
            extraManager = new ExtraManager(dataAccess, dataWriter, dataRemover);
            pictureManager = new PictureManager(dataAccess, dataWriter, dataRemover);
            userRepository = new UserRepository(dataAccess, dataWriter, dataRemover);
            administratorRepository = new AdministratorRepository(dataAccess, dataWriter, dataRemover);
            peopleManager = new PeopleManager(userRepository, administratorRepository);
            LoadAllData();
        }

        public void LoadAllData()
        { 
            carManager.LoadCars();
            newsManager.LoadNews();
            rentManager.LoadRentals();
            userRepository.LoadUSers();
            administratorRepository.LoadAdmins();
        }
    }
}