using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Picture
    {
        public int Id { get; set; }
        public string PictureURL { get; set; }

        public Picture(int Id, string URL) 
        {
            this.Id = Id;
            this.PictureURL = URL;
        }

        public Picture(string URL)
        {
            this.PictureURL = URL;
        }
    }
}
