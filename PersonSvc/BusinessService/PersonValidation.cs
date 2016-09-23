using PTJ.Base.BusinessRules.Interfaces;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSvc.BusinessService
{
    public class PersonValidation : IValidation<PersonViewModel>
    {
        private IApplicationDbContext db;
      
        public PersonValidation(IApplicationDbContext _db)
        {
            db = _db;
        }
     

        public bool AllreadyExist(string entityId, ref string validationMsg)
        {
            var allreadyExist = (from p in db.Person
                                 where p.PersonNummer == entityId
                                 select p.PersonNummer).FirstOrDefault();

            if (String.IsNullOrEmpty(allreadyExist))
            {
                return false;   
            }
            else
            {
                validationMsg = "Error Create Person allready exist " + entityId;
                return true;
            }
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

            return validate;
        }

        public bool CheckCreateValues(IViewModel<PersonViewModel> model)
        {
            throw new NotImplementedException();
        }

        public bool CheckCreateValues(IViewModel<PersonViewModel> model, ref string validationMsg)
        {
            throw new NotImplementedException();
        }

        public bool CheckUpdatesValues(IViewModel<PersonViewModel> entity)
        {
            throw new NotImplementedException();
        }

        public bool DoChildExist(long entityId)
        {
            throw new NotImplementedException();
        }

        public bool DoParentEntityExist(long entityId)
        {
            throw new NotImplementedException();
        }

    
    }
}
