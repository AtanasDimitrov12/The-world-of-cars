﻿
namespace DTO.Interfaces
{
    public class DescendingBrandComparer : IComparer<CarDTO>
    {
        public int Compare(CarDTO x, CarDTO y)
        {
            if (x == null || y == null)
            {
                return x == null ? (y == null ? 0 : -1) : 1;
            }
            return string.Compare(y.Brand, x.Brand); 
        }
    }
}
