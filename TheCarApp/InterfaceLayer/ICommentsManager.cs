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
        bool AddComment(CarNews news, Comment comment, out string errorMessage);
        bool RemoveComment(CarNews news, Comment comment, out string errorMessage);
    }
}
