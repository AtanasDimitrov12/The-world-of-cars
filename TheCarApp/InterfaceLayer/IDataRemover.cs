using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface IDataRemover
    {
        string RemoveCar(int CarId);
        string RemoveCarDescription(int CarId);
        string RemoveNews(int NewsId);
        string RemoveCarExtras(int CarId);
        string RemoveCarPictures(int CarId);
        string RemoveComment(int CommentId);
        string RemoveExtra(int ExtraId);
        string RemovePicture(int PicId);
        string RemoveRental(int RentalId);
        string RemoveUser(int UserId);
        string RemoveAdmin(int AdminId);
    }
}
