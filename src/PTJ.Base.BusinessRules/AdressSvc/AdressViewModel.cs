using PTJ.Base.BusinessRules.Interfaces;
using PTJ.DataLayer.Models;
using System.Collections.Generic;


namespace PTJ.Base.BusinessRules.AdressSvc
{
    public class AdressViewModel 
    {

        public long Id { get; set; }

        public string GatuAdress { get; set; }

        public string Postnummer { get; set; }

        public string Stad { get; set; }

        public string Land { get; set; }

        public string Mail { get; set; }

        public string Telefon { get; set; }

        public string AdressvariantText { get; set; }

        public long Adressvariant { get; set; }

        public string AdressTypText { get; set; }

        public long AdressTyp { get; set; }
    }
}

