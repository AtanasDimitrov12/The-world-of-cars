using DTO;
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

        bool AddNews(CarNews carnews, out string errorMessage);
        bool DeleteNews(CarNews carnews, out string errorMessage);
        bool UpdateNews(CarNews news, out string errorMessage);
        List<CarNews> GetNewsASC();
        List<CarNews> GetNewsDESC();
        CarNews GetNewsById(int id);
        CarNews MapCarNewsDtoToCarNews(CarNewsDTO newsDTO);
        bool LoadNews(out string errorMessage);
    }
}