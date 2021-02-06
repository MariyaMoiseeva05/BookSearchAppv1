using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Locality
    {
        public Locality() {

            Adverts = new HashSet<Advert>();
        }
        [Key]
        public int LocalityId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Timezone { get; set; }
        public virtual ICollection<Advert> Adverts { get; set; }
    }
}
