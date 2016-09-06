using System;
using System.Collections.Generic;

namespace PTJ.DataLayer.Models
{
    public partial class PersonPatient
    {
        public long Id { get; set; }
        public long PersonFkid { get; set; }
        public long PatientFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        public virtual Person PersonFk { get; set; }
    }
}
