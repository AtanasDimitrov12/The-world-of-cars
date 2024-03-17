using Entity_Layer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Layer
{
    public class Forum
    {
        private CarTopics CarTopics { get; set; }
        private string Title { get; set; }  
        private string Description { get; set; }
        private DateTime StartDate { get; set; }
        private DateTime EndDate { get; set; }
        private List<Reply> replies;

        public Forum(CarTopics carTopics, string title, string description, DateTime startDate, DateTime endDate)
        {
            CarTopics = carTopics;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            replies = new List<Reply>();
        }

        public void AddReply(Reply Reply)
        { 
            replies.Add(Reply);
        }
    }
}
