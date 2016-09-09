using PTJ.DataLayer.Models;
using System.Collections.Generic;


namespace PTJ.Base.BusinessRules.ViewModels
{
    public class PersonViewModel 
    {
        public Person Person { get; set; }

        public PersonAnnanPerson PersonAnnanPerson { get; set; }

        public PersonAnstalld PersonAnstalld { get; set; }

        public PersonKonsult PersonKonsult { get; set; }

        public PersonPatient PersonPatient { get; set; }

        public PersonSjukHalsovardsPersonal PersonSjukHalsovardsPersonal { get; set; }
    }
}
