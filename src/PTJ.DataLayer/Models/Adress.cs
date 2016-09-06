using System;
using System.Collections.Generic;

namespace UserService.Models
{
    public partial class Adress
    {
        public Adress()
        {
            GatuAdress = new HashSet<GatuAdress>();
            Mail = new HashSet<Mail>();
            OrganisationAdress = new HashSet<OrganisationAdress>();
            PersonAdress = new HashSet<PersonAdress>();
            Telefon = new HashSet<Telefon>();
        }

        public long Id { get; set; }
        public long AdressTypFkid { get; set; }
        public long AdressVariantFkid { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        public virtual ICollection<GatuAdress> GatuAdress { get; set; }
        public virtual ICollection<Mail> Mail { get; set; }
        public virtual ICollection<OrganisationAdress> OrganisationAdress { get; set; }
        public virtual ICollection<PersonAdress> PersonAdress { get; set; }
        public virtual ICollection<Telefon> Telefon { get; set; }
        public virtual AdressTyp AdressTypFk { get; set; }
        public virtual AdressVariant AdressVariantFk { get; set; }
    }
}
