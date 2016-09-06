using System;
using System.Collections.Generic;

namespace UserService.Models
{
    public partial class AdressVariant
    {
        public AdressVariant()
        {
            Adress = new HashSet<Adress>();
        }

        public long Id { get; set; }
        public long AdressTypFkid { get; set; }
        public string Variant { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        public virtual ICollection<Adress> Adress { get; set; }
        public virtual AdressTyp AdressTypFk { get; set; }
    }
}
