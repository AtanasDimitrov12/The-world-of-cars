using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Comment
    {
        private User User { get; set; }
        private DateTime Date { get; set; }
        private string Message { get; set; }

        public Comment(User user, DateTime date, string message)
        {
            this.User = user;
            this.Date = date;
            this.Message = message;
        }
    }
}
