using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Interfaces
{
    public class CarNewsDateAscendingComparer : IComparer<CarNews>
    {
        public int Compare(CarNews x, CarNews y)
        {
            if (x == null || y == null)
            {
                return x == null ? (y == null ? 0 : -1) : 1;
            }
            return DateTime.Compare(x.ReleaseDate, y.ReleaseDate);
        }
    }
}
