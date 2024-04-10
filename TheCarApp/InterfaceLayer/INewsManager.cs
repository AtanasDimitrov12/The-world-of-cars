using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer
{
    public interface INewsManager
    {
        void AddNews(CarNews carnews);
        void DeleteNews(CarNews carnews);
        void LoadNews();
    }
}
