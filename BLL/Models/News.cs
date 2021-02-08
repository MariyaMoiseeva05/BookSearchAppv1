using System;
using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class NewsModel
    {
        public int NewsId { get; set; }
        public string Topic { get; set; }
        public string Title { get; set; }
        public DateTime Date_of_creation { get; set; }
        public string Content { get; set; }
        public string ImageLink { get; set; }
        public string ImagePath { get; set; }
        public string Source { get; set; }
        public virtual ICollection<News_Tags> Tags { get; set; } = new HashSet<News_Tags>();
        public virtual ICollection<Comment_News> Comments { get; set; } = new HashSet<Comment_News>();
        public NewsModel() { }
        public NewsModel(News n)
        {
            NewsId = n.NewsId;
            Topic = n.Topic;
            Title = n.Title;
            Date_of_creation = n.Date_of_creation;
            Content = n.Content;
            Tags = n.Tags;
            Comments = n.Comments;
            Source = n.Source;
            ImageLink = n.ImageLink;
            ImagePath = n.ImagePath;

        }
    }
}
