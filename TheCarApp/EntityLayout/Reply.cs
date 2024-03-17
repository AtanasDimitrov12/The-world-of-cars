using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Reply
    {
        private User User { get; set; }
        private DateTime Date { get; set; }
        private string Message { get; set; }

        public Reply(User user, DateTime date, string message)
        {
            this.User = user;
            this.Date = date;
            this.Message = message;
        }
    }
}
