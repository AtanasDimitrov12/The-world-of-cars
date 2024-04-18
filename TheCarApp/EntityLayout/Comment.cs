using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public Comment(int id, int userId, DateTime date, string message)
        {
            this.Id = id;
            this.UserId = userId;
            this.Date = date;
            this.Message = message;
        }

        public Comment() 
        {
        
        }
    }
}
