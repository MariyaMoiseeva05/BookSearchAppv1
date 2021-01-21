using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class ReviewModel
    {
        public int RewiewId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Type { get; set; }
        public int? BookID { get; set; }
        public double Rating { get; set; }
        //public int? UserID { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        // public virtual User User { get; set; }
        public ReviewModel() { }
        public ReviewModel(Review r)
        {

            RewiewId = r.RewiewId;
            Title = r.Title;
            Text = r.Text;
            Type = r.Type;
            BookID = r.BookID;
            //UserID = r.UserID;
            Book = r.Book;
            //User = r.User;
            Rating = r.Rating;
            Comments = r.Comments;
        }

    }
}
