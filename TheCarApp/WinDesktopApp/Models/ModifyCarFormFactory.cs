using EntityLayout;
using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDesktopApp.Models
{
    public class ModifyCarFormFactory : ICarFormFactory
    {
        public ICarForm CreateCarForm(Car car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            return new ModifyCarForm(car, cm, em, picManager);
        }
    }
}
