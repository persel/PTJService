using PTJ.Base.BusinessRules.AdressSvc;
using PTJ.Base.BusinessRules.Interfaces;
using PTJ.DataLayer.Models;
using System.Collections.Generic;


namespace PTJ.Base.BusinessRules.PersonSvc
{
    public class PersonAdressViewModel : IViewModel<PersonAdressViewModel>
    {
        public long Id { get; set; }

        public string ForNamn { get; set; }

        public string MellanNamn { get; set; }

        public string EfterNamn { get; set; }

        public string PersonNummer { get; set; }

        public string SkapadDatum { get; set; }

        public bool Anstalld { get; set; }

        public string AnstallDatum { get; set; }

        public bool Konsult { get; set; }

        public string KonsultDatum { get; set; }

        public bool Patient { get; set; }

        public bool PersonSjukHalsovardsPersonal { get; set; }

        public List<AdressViewModel> Adress { get; set; }
    }
}
