using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarDataRemover
    {
        string RemoveCar(int CarId);
        string RemoveCarDescription(int CarId);
        string RemoveCarExtras(int CarId);
        string RemoveCarPictures(int CarId);
        string RemoveCarViewsHistory(int CarId);
        string RemoveExtra(int ExtraId);
        string RemovePicture(int PicId);
    }
}
