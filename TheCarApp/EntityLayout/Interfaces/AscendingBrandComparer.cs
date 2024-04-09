using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer.Interfaces
{
    public class AscendingBrandComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            if (x == null || y == null)
            {
                return x == null ? (y == null ? 0 : -1) : 1;
            }
            return string.Compare(x.brand, y.brand);
        }
    }
}
