using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICarNewsDataRemover
    {
        string RemoveNews(int NewsId);
        string RemoveComment(int CommentId);
    }
}
