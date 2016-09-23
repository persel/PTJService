using PTJ.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTJ.DataLayer.MockStore
{
    public class MockStore
    {
        public List<Person> Person { get; set; }


        public MockStore()
        {
            this.Person = CreateTestPersons();
        }

        private List<Person> CreateTestPersons()
        {
            List<Person> _persons = new List<Person>();

            for (int i = 0; i < 4; i++)
            {
                Person p = new Person();

                p.ForNamn = "Nisse" + i;
                p.ForNamn = "Svensson";
                p.MellanNamn = "karl";

                p.PersonNummer = "195012121234";
                p.Id = i;
                p.SkapadDatum = DateTime.Now;
                _persons.Add(p);
            }

            return _persons;
        }
    }

}
