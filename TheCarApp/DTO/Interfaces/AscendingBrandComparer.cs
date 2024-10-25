﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public class AscendingBrandComparer : IComparer<CarDTO>
    {
        public int Compare(CarDTO x, CarDTO y)
        {
            if (x == null || y == null)
            {
                return x == null ? (y == null ? 0 : -1) : 1;
            }
            return string.Compare(x.Brand, y.Brand);
        }
    }
}