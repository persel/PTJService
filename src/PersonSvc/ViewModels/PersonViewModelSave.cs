using PTJ.Base.BusinessRules.Interfaces;
using PTJ.DataLayer.Models;
using System.Collections.Generic;


namespace PersonSvc.ViewModels
{
    public class PersonViewModelSave
    {

        public long Id { get; set; }
        public string ForNamn { get; set; }
        public string MellanNamn { get; set; }
        public string EfterNamn { get; set; }
        public string PersonNummer { get; set; }
        public string UppdateradAvAlias { get; set; }

    }
}
