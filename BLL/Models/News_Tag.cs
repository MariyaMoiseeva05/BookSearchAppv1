using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class News_TagModel
    {
        public int NewsId { get; set; }

        public virtual News News { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
        public News_TagModel() { }
        public News_TagModel(News_Tags nt) 
        {
            NewsId = nt.NewsId;
            News = nt.News;
            TagId = nt.TagId;
            Tag = nt.Tag;
        
        }
    }
}
