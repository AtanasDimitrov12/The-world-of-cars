using AutoMapper;
using Data;
using DatabaseAccess;
using InterfaceLayer;
using Manager_Layer;
using ManagerLayer.Strategy;
using Microsoft.EntityFrameworkCore;

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
        public IUserManager UserManager { get; set; }
        public IAdministratorManager AdministratorRepository { get; set; }
        public IDataAccess DataAccess { get; set; }
        public IPeopleDataWriter PeopleDataWriter { get; set; }
        public ICarDataWriter CarDataWriter { get; set; }
        public ICarNewsDataWriter CarNewsDataWriter { get; set; }
        public ICarDataRemover CarDataRemover { get; set; }
        public ICarNewsDataRemover CarNewsDataRemover { get; set; }
        public IPeopleDataRemover PeopleDataRemover { get; set; }
        public IRentalStrategyFactory rentalStrategyFactory { get; set; }
        public Mapping.Configuration mappingConfiguration { get; set; } // Mapping Configuration is used here
        public CarAppContext context { get; set; }
        public IMapper mapper { get; set; }

        public ProjectManager()
        {
            mappingConfiguration = new Mapping.Configuration();  // Mapping Configuration object
            mapper = mappingConfiguration.Config();
            var optionsBuilder = new DbContextOptionsBuilder<CarAppContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-IL35000\SQLEXPRESS;Database=CarApp;Integrated Security=true;TrustServerCertificate=True");
            context = new CarAppContext(optionsBuilder.Options);
            DataAccess = new DataAccess(context);
            PeopleDataWriter = new PeopleDataWriter(context);
            CarDataWriter = new CarDataWriter(context);
            CarNewsDataWriter = new CarNewsDataWriter(context);
            CarDataRemover = new CarDataRemover(context);
            CarNewsDataRemover = new CarNewsDataRemover(context);
            PeopleDataRemover = new PeopleDataRemover(context);
            rentalStrategyFactory = new RentalStrategyFactory();
            CarManager = new CarManager(mapper, DataAccess, CarDataWriter, CarDataRemover);
            NewsManager = new NewsManager(DataAccess, CarNewsDataWriter, CarNewsDataRemover, mapper);
            CommentsManager = new CommentsManager(CarNewsDataWriter, CarNewsDataRemover, mapper);
            ExtraManager = new ExtraManager(DataAccess, CarDataWriter, CarDataRemover, mapper);
            PictureManager = new PictureManager(DataAccess, CarDataWriter, CarDataRemover, mapper);
            UserManager = new UserManager(DataAccess, PeopleDataWriter, PeopleDataRemover, mapper);
            AdministratorRepository = new AdministratorManager(DataAccess, PeopleDataWriter, PeopleDataRemover, mapper);
            PeopleManager = new PeopleManager(UserManager, AdministratorRepository);
            RentManager = new RentManager(DataAccess, PeopleDataWriter, PeopleDataRemover, PeopleManager, CarManager, rentalStrategyFactory, mapper);
            LoadAllData();
        }

        public async void LoadAllData()
        {
            await CarManager.LoadCarsAsync();
            await NewsManager.LoadNewsAsync();
            await UserManager.LoadUsersAsync();
            await AdministratorRepository.LoadAdminsAsync();
            await RentManager.LoadRentalsAsync();
        }
    }
}
