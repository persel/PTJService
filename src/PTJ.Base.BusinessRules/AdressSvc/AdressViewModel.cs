﻿using PTJ.Base.BusinessRules.Interfaces;
using PTJ.DataLayer.Models;
using System.Collections.Generic;


namespace PTJ.Base.BusinessRules.AdressSvc
{
    public class AdressViewModel 
    {
        public Adress Adress { get; set; }

        public GatuAdress GatuAdress { get; set; }

        public Mail Mail { get; set; }

        public Telefon Telefon { get; set; }

        public AdressVariant Adressvariant { get; set; }
    }
}
