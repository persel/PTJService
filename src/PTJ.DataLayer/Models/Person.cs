using System;
using System.Collections.Generic;

namespace PTJ.DataLayer.Models
{
    public partial class Person
    {
        public Person()
        {
            PersonAdress = new HashSet<PersonAdress>();
            PersonAnnanPerson = new HashSet<PersonAnnanPerson>();
            PersonAnstalld = new HashSet<PersonAnstalld>();
            PersonKonsult = new HashSet<PersonKonsult>();
            PersonPatient = new HashSet<PersonPatient>();
            PersonSjukHälsovårdsPersonal = new HashSet<PersonSjukHalsovardsPersonal>();
        }

        public long Id { get; set; }
        public string ForNamn { get; set; }
        public string MellanNamn { get; set; }
        public string EfterNamn { get; set; }
        public string PersonNummer { get; set; }
        public DateTime SkapadDatum { get; set; }
        public DateTime? UppdateradDatum { get; set; }
        public string UppdateradAv { get; set; }

        public virtual ICollection<PersonAdress> PersonAdress { get; set; }
        public virtual ICollection<PersonAnnanPerson> PersonAnnanPerson { get; set; }
        public virtual ICollection<PersonAnstalld> PersonAnstalld { get; set; }
        public virtual ICollection<PersonKonsult> PersonKonsult { get; set; }
        public virtual ICollection<PersonPatient> PersonPatient { get; set; }
        public virtual ICollection<PersonSjukHalsovardsPersonal> PersonSjukHälsovårdsPersonal { get; set; }
    }
}
