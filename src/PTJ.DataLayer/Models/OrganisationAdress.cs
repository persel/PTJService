using System;
using System.Collections.Generic;

namespace UserService.Models
{
    public partial class OrganisationAdress
    {
        public long Id { get; set; }
        public int OrganisationFkid { get; set; }
        public int AdressFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime? SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        public virtual Adress AdressFk { get; set; }
        public virtual Organisation OrganisationFk { get; set; }
    }
}
