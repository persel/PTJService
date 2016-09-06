using System;
using System.Collections.Generic;

namespace PTJ.DataLayer.Models
{
    public partial class PersonAdress
    {
        public long Id { get; set; }
        public long PersonFkid { get; set; }
        public long AdressFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime? SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        public virtual Adress AdressFk { get; set; }
        public virtual Person PersonFk { get; set; }
    }
}
