﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPeopleDataRemover
    {
        void RemoveUser(int UserId);
        void RemoveAdmin(int AdminId);
        void RemoveRental(int RentalId);
    }
}
