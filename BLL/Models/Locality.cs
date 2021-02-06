using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class LocalityModel
    {
        public int LocalityId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Timezone { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
        public LocalityModel() { }
        public LocalityModel(Locality l) {
            LocalityId = l.LocalityId;
            Type = l.Type;
            Name = l.Name;
            Timezone = l.Timezone;
            Adverts = l.Adverts;


        }
    }
}
