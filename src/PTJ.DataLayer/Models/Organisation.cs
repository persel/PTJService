using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PTJ.DataLayer.Models
{
    public partial class Organisation
    {
        public Organisation()
        {
            OrganisationAdress = new HashSet<OrganisationAdress>();
        }
        [Key]
        public long Id { get; set; }
        public string OrganisationsId { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpDateradDatum { get; set; }
        public string UpdateradAv { get; set; }
        public int? IngarIorganisation { get; set; }

        public virtual ICollection<OrganisationAdress> OrganisationAdress { get; set; }
        public virtual Organisation IngarIorganisationNavigation { get; set; }
        public virtual ICollection<Organisation> InverseIngarIorganisationNavigation { get; set; }
    }
}
