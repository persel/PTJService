﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PTJ.DataLayer.Models
{
    [Table("PersonSjukHalsovardsPersonal", Schema = "Person")]
    public partial class PersonSjukHalsovardsPersonal
    {
        [Key]
        public long Id { get; set; }
        public long PersonFkid { get; set; }
        public long SjukHalsovardsPersonalFkid { get; set; }
        public string UpdateradAv { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }

        //public virtual Person PersonFk { get; set; }
    }
}
