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
        ICarForm CreateViewForm(Car car);
        ICarForm CreateModifyForm(Car car);
        ICarForm CreateAddForm();
    }

}
