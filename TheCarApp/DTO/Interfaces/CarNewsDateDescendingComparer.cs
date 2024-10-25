﻿
namespace DTO.Interfaces
{
    public class CarNewsDateDescendingComparer : IComparer<CarNewsDTO>
    {
        public int Compare(CarNewsDTO x, CarNewsDTO y)
        {
            if (x == null || y == null)
            {
                return x == null ? (y == null ? 0 : -1) : 1;
            }
            return DateTime.Compare(y.ReleaseDate, x.ReleaseDate);
        }
    }
}
