using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class NewsAdministrator
    {
        CarNews CarNews { get; set; }
        Comment comment { get; set; }

        private List<CarNews> news { get; set;}

        public NewsAdministrator() 
        {
            news = new List<CarNews>();
        }

        public void AddNews(CarNews News)
        {
            news.Add(News);
        }

        public void DeleteNews(CarNews News) 
        {
            news.Remove(News);
        }
    }
}
