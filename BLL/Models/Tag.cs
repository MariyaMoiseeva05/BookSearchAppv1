using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<News_Tags> News { get; set; } = new HashSet<News_Tags>();
        public TagModel() { }
        public TagModel(Tag tg)
        {
            Id = tg.Id;
            Name = tg.Name;
            News = tg.News;
        }
    }
}
