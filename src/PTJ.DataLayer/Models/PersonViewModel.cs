using System.Collections.Generic;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PTJ.DataLayer.Models
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
