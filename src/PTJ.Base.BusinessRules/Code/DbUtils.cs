using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PTJ.DataLayer.Models;

namespace PTJ.Base.BusinessRules.Code
{
    public class DbUtils
    {
        private ModelDbContext db;

        public DbUtils(ModelDbContext _db)
        {
            db = _db;
        }

        public long GetNewDbId(string tableName)
        {
            long Id = 0;

            switch (tableName)
            {
                case "Person":
                    Id = db.Person.Select(s => s.Id).Max() + 1;
                    break;
                case "PersonAnnanPerson":
                    Id = db.PersonAnnanPerson.Select(s => s.Id).Max() + 1;
                    break;
                case "PersonAnstalld":
                    Id = db.PersonAnstalld.Select(s => s.Id).Max() + 1;
                    break;
                case "PersonKonsult":
                    Id = db.PersonKonsult.Select(s => s.Id).Max() + 1;
                    break;
                case "PersonPatient":
                    Id = db.PersonPatient.Select(s => s.Id).Max() + 1;
                    break;
                case "PersonSjukHalsovardsPersonal":
                    Id = db.PersonSjukHalsovardsPersonal.Select(s => s.Id).Max() + 1;
                    break;
                default:
                    break;
            }
            return Id;
        }
    }
}
