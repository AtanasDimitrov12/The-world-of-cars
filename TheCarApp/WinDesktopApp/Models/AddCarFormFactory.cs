using InterfaceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Manager_Layer;

namespace WinDesktopApp.Models
{
    public class AddCarFormFactory : ICarFormFactory
    {
        public ICarForm CreateCarForm(CarDTO car, ICarManager cm, IExtraManager em, IPictureManager picManager)
        {
            return new AddCarForm(cm, em, picManager);
        }
    }
} 
