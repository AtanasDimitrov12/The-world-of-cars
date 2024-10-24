using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Manager_Layer;

namespace InterfaceLayer
{
    public interface ICarFormFactory
    {
        ICarForm CreateCarForm(CarDTO car, ICarManager cm, IExtraManager em, IPictureManager picManager);
    }

}
