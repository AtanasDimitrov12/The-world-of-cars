using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IDataRemover
    {
        string RemoveCar(int CarId, int ExtraId, int PictureId);
        string RemoveCarDescription(int CarId);
        string RemoveNews(int NewsId);
        string RemoveCarExtras(int CarId, int ExtraId);
        string RemoveCarPictures(int CarId, int PictureId);
        string RemoveComment(int CommentId);
        string RemoveExtra(int ExtraId);
        string RemovePicture(int PicId);
        string RemoveRental(int RentalId);
        string RemoveUser(int UserId);
        string RemoveAdmin(int AdminId);
    }
}
