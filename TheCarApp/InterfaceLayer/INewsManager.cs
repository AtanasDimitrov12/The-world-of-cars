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
        List<CarNews> news { get; set; }

        string AddNews(CarNews carnews);
        void DeleteNews(CarNews carnews);
        void UpdateNews(CarNews news);
        CarNews GetNewsById(int id);
        void LoadNews();
    }
}
