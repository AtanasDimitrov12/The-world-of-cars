using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IDataRemover
    {
        int RemoveCar(int CarId, int ExtraId, int PictureId);
        int RemoveCarDescription(int CarId);
        int RemoveNews(int NewsId);
        int RemoveCarExtras(int CarId, int ExtraId);
        int RemoveCarPictures(int CarId, int PictureId);
        int RemoveComment(int CommentId);
        int RemoveRental(int RentalId);
        int RemoveUser(int UserId);
        int RemoveAdmin(int AdminId);
    }
}
