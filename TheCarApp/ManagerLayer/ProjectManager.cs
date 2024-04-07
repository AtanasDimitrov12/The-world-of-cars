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
        CarManager carManager { get; set; }
        NewsManager newsManager { get; set; }
        RentManager rentManager { get; set; }
        PeopleManager peopleManager { get; set; }

        public ProjectManager()
        {
            carManager = new CarManager();
            newsManager = new NewsManager();    
            rentManager = new RentManager();    
            peopleManager = new PeopleManager();
        }

    }
}
