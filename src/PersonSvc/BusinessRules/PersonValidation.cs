using PersonSvc.BusinessRules.Interfaces;
using PTJ.Base.BusinessRules.Interfaces;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessRules
{
    public class PersonValidation : IPersonValidation
    {
        private IValueUtils valueUtils;

        public PersonValidation(IValueUtils _valueUtils)
        {
            valueUtils = _valueUtils;
        }

        public bool CheckCreateValues(PersonViewModel model, ref string validationMsg)
        {
            bool validate = true;
          
            if (model.Person.PersonNummer != String.Empty && !String.IsNullOrEmpty(model.Person.ForNamn) && !String.IsNullOrEmpty(model.Person.EfterNamn))
            {
                if(model.Person.PersonNummer.Length < 4 )
                {
                    validate = false;
                    validationMsg += "Not a valid PersonNummer:";
                }

                if (model.Person.ForNamn.Length < 2 )
                {
                    validate = false;
                    validationMsg += " Not a valid ForNamn:";
                }

                if (model.Person.EfterNamn.Length < 2)
                {
                    validate = false;
                    validationMsg += " Not a valid EfterNamn:";
                }

                //ToDO add more check and move out msg in text file.. 

            }
            else
            {
                validate = false;
            }

            return validate;
        }


        public bool CheckUpdatesValues(PersonViewModel model, ref string validationMsg)
        {
            throw new NotImplementedException();
        }

      
  
    
    }
}
