using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IPictureManager
    {
        List<Picture> pictures { get; set; }
        string AddPicture(Picture picture);
        string RemovePicture(Picture picture);
        int GetPicId(string URL);
    }

}
