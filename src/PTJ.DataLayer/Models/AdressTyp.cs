using System;
using System.Collections.Generic;

namespace PTJ.DataLayer.Models
{
    public partial class AdressTyp
    {
        public AdressTyp()
        {
            Adress = new HashSet<Adress>();
            AdressVariant = new HashSet<AdressVariant>();
        }

        public long Id { get; set; }
        public string Typ { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        public virtual ICollection<Adress> Adress { get; set; }
        public virtual ICollection<AdressVariant> AdressVariant { get; set; }
    }
}
