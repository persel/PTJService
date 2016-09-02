using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.DataLayer
{
    public class Person
    {
        [Required]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long Persnr { get; set; }

        [Required]
        [MaxLength(10)]
        public string Username { get; set; }

        [MaxLength(256)]
        public string Fname { get; set; }

        [MaxLength(256)]
        public string Lname { get; set; }

        public List<Adress> Adress { get; set; }
    }
}
