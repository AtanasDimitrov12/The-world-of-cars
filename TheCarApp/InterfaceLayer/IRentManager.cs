﻿using Entity_Layer.Enums;
using Entity_Layer;
using EntityLayout;
using Manager_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IRentManager
    {
        List<RentACar> rentalHistory { get; set; }
        string RentACar(User user, Car car, DateTime startDate, DateTime endDate);
        void UpdateRental(RentACar rental, RentStatus newStatus);
        string LoadRentals();
    }
}
