using PTJ.Base.BusinessRules.Interfaces;
using PTJ.DataLayer.Models;
using System.Collections.Generic;


namespace PersonSvc.ViewModels
{
    public class EmployeeViewModelSave
    {

        public long Id { get; set; }

        public string Alias { get; set; }

        public int Ftgnr { get; set; }

        public string Enhet { get; set; }

        public string Befnr { get; set; }

        public int Kstnr { get; set; }

        public string Ansvarig { get; set; }

        public int? Befkod { get; set; }

        public string Beftext { get; set; }

        public string AvtalsText { get; set; }

    }
}
