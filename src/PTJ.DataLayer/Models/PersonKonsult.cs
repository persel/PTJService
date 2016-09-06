using System;
using System.Collections.Generic;

namespace UserService.Models
{
    public partial class PersonKonsult
    {
        public long Id { get; set; }
        public long PersonFkid { get; set; }
        public long KonsultFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        public virtual Person PersonFk { get; set; }
    }
}
