using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.DataLayer
{
    public class Organisation
    {
        [Required]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrganisationsId { get; set; }

        [Required]
        public DateTime SkapadDatum { get; set; }

        public DateTime UpDateradDatum { get; set; }

        [MaxLength(100)]
        public string UpdateradAv { get; set; }

        public int IngarIOrganisation { get; set; }
    }
}
