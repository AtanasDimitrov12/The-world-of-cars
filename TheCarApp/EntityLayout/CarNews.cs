using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class CarNews
    {
        public string NewsDescription { get; set; }
        public string ReleaseDate { get; set; }
        //public byte[] Images { get; set; }

        public CarNews(string newsDescription, string releaseDate)
        {
            NewsDescription = newsDescription;
            ReleaseDate = releaseDate;
           //Images = images;
        }
    }
}
