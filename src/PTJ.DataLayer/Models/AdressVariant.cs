﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTJ.DataLayer.Models
{
    [Table("AdressVariant", Schema = "Adress")]
    public partial class AdressVariant
    {
        //public AdressVariant()
        //{
        //    Adress = new HashSet<Adress>();
        //}
        [Key]
        public long Id { get; set; }

        [ForeignKey("Id")]
        public long AdressTypFkid { get; set; }
        public string Variant { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UpdateradDatum { get; set; }
        public string UpdateradAv { get; set; }

        //public virtual ICollection<Adress> Adress { get; set; }
        //public virtual AdressTyp AdressTypFk { get; set; }
    }
}
