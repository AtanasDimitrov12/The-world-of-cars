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
        public CarManager carManager { get; set; }
        public NewsManager newsManager { get; set; }
        public CommentsManager commentsManager { get; set; }
        public RentManager rentManager { get; set; }
        public PeopleManager peopleManager { get; set; }
        public ExtraManager extraManager { get; set; }
        public PictureManager pictureManager { get; set; }
        public IUserRepository userRepository { get; set; }
        public IAdministratorRepository administratorRepository { get; set; }

        public ProjectManager()
        {
            IDataAccess dataAccess = new DataAccess();
            IDataWriter dataWriter = new DataWriter();
            IDataRemover dataremover = new DataRemover();
            carManager = new CarManager(dataAccess, dataWriter, dataremover);
            newsManager = new NewsManager(dataAccess, dataWriter, dataremover);
            commentsManager = new CommentsManager(dataAccess, dataWriter, dataremover);
            rentManager = new RentManager();  
            extraManager = new ExtraManager(dataAccess, dataWriter, dataremover);
            pictureManager = new PictureManager(dataAccess, dataWriter, dataremover);
            userRepository = new UserRepository(dataAccess, dataWriter, dataremover);
            administratorRepository = new AdministratorRepository(dataAccess, dataWriter, dataremover);
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