using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface ICommentsManager
    {
        string AddComment(CarNews news, Comment comment);
        string RemoveComment(CarNews news, Comment comment);
    }
}
