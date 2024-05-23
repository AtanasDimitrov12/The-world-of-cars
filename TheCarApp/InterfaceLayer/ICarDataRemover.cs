using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarDataRemover
    {
        void RemoveCar(int CarId);
        void RemoveCarDescription(int CarId);
        void RemoveCarExtras(int CarId);
        void RemoveCarPictures(int CarId);
        void RemoveCarViewsHistory(int CarId);
        void RemoveExtra(int ExtraId);
        void RemovePicture(int PicId);
    }
}
