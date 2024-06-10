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
        bool AddPicture(Picture pic, out string errorMessage);
        bool RemovePicture(Picture pic, out string errorMessage);
        bool LoadPictures(out string errorMessage);
        int GetPicId(string URL);
    }

}
