using PTJ.DataLayer.Models;
using System.Collections.Generic;


namespace PTJ.Base.BusinessRules.ViewModels
{
    public class PersonAdressViewModel 
    {
        public Person Person { get; set; }

        public List<AdressViewModel> Adress { get; set; }
    }
}
