
namespace DTO
{
    public class CarNewsDTO
    {
        public int Id { get; set; }
        public string NewsDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImageURL { get; set; }
        public int NrOfComments { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ShortIntro { get; set; }
        public List<CommentDTO> Comments { get; set; }
    }
}
