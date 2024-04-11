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
        void AddComment(CarNews news, Comment comment, User user);
        void RemoveComment(CarNews news, Comment comment);
    }
}
