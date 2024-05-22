using EntityLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarFormFactory
    {
        ICarForm CreateCarForm(Car car, ICarManager cm, IExtraManager em, IPictureManager picManager);
    }

}
