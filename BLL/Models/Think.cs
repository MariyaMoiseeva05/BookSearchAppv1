using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class ThinkModel
    {
        public int ThinkId { get; set; }
        public string? UserId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Date_of_creation { get; set; }
        public virtual User User { get; set; }

        public ThinkModel() { }
        public ThinkModel(Think t)
        {
            ThinkId = t.ThinkId;
            UserId = t.UserId;
            Content = t.Content;
            Title = t.Title;
            Date_of_creation = t.Date_of_creation;
            User = t.User;

        }
    }
}
