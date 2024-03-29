using EntityLayout;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager_Layer
{
    public class RentACar
    {
        private User user { get; set; }
        private Car car { get; set; }
        private DateTime StartDate { get; set; } 
        private DateTime ReturnDate { get; set; }
        private  RentStatus status { get; set; }

        public RentACar(User user, Car car, DateTime startDate, DateTime returnDate, RentStatus Status)
        {
            this.user = user;
            this.car = car;
            this.StartDate = startDate;
            this.ReturnDate = returnDate;
            this.status = Status;
        }
    }
}
