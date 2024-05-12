using EntityLayout;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Enums;

namespace Manager_Layer
{
    public class RentACar
    {
        public User user { get; set; }
        public Car car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentStatus status { get; set; }
        public decimal TotalPrice {  get; set; }

        public RentACar(User user, Car car, DateTime startDate, DateTime returnDate, RentStatus Status)
        {
            this.user = user;
            this.car = car;
            this.StartDate = startDate;
            this.ReturnDate = returnDate;
            this.status = Status;
        }

        public void ChangeStatus(RentStatus Status)
        {
            this.status = Status;
        }
    }
}
