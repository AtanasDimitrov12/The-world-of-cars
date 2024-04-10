﻿using Database;
using DatabaseAccess;
using Entity_Layer;
using InterfaceLayer;
using Manager_Layer;
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
        public RentManager rentManager { get; set; }
        public PeopleManager peopleManager { get; set; }
        public ExtraManager extraManager { get; set; }
        public PictureManager pictureManager { get; set; }

        public ProjectManager()
        {
            IDataAccess dataAccess = new DataAccess();
            IDataWriter dataWriter = new DataWriter();
            IDataRemover dataremover = new DataRemover();
            carManager = new CarManager(dataAccess, dataWriter, dataremover);
            newsManager = new NewsManager(dataAccess, dataWriter, dataremover);    
            rentManager = new RentManager();    
            peopleManager = new PeopleManager();
            extraManager = new ExtraManager(dataWriter, dataremover);
            pictureManager = new PictureManager(dataWriter, dataremover);
        }

        public void LoadAllData()
        { 
            carManager.LoadCars();
            newsManager.LoadNews();
            rentManager.LoadRentals();
            peopleManager.LoadPeople();
        }
    }
}