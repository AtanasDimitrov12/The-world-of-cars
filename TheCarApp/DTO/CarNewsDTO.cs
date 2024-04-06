using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTO
{
    public class CarNewsDTO
    {
        public int Id { get; set; }
        public string NewsDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        public int NrOfMessages { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ShortIntro { get; set; }
        public List<CommentDTO> comments { get; set; }
    }
}
