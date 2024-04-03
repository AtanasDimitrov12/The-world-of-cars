using Entity_Layer;
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
        CarManager carManager;
        NewsManager newsManager;
        RentManager rentManager;

        public ProjectManager()
        { 
            CarManager = new CarManager();
            NewsManager = new NewsManager();    
            RentManager = new RentManager();    
        }

        public CarManager CarManager { get => carManager; set => carManager = value; }
        public NewsManager NewsManager { get => newsManager; set => newsManager = value; }
        public RentManager RentManager { get => rentManager; set => rentManager = value; }
    }
}
