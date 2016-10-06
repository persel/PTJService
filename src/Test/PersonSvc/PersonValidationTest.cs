
using PersonSvc.BusinessRules;
using PersonSvc.BusinessRules.Utils;
using PersonSvc.ViewModels;
using PTJ.Base.BusinessRules.PersonSvc;
using PTJ.DataLayer.Models;
using System;
using Xunit;

namespace Test.PersonSvc
{
    public class PersonValidationTest
    {
    
        [Fact]
        public void CheckCreateValuesTest()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

          
            String str = "";

            PersonViewModelSave PVmodel = new PersonViewModelSave();

            PVmodel.PersonNummer = "12345";
            PVmodel.ForNamn = "Per";
            PVmodel.EfterNamn = "Nilsson";

            Assert.True( pv.CheckCreateValues(PVmodel, ref str) == true );

        }

        [Fact]
        public void CheckCreateValuesTestNotValidPersnr()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

            
            String str = "";

            PersonViewModelSave PVmodel = new PersonViewModelSave();

            PVmodel.PersonNummer = "12";
            PVmodel.ForNamn = "Per";
            PVmodel.EfterNamn = "Nilsson";

            Assert.True(pv.CheckCreateValues(PVmodel, ref str) == false);

            Assert.True(str == "Not a valid PersonNummer:");

        }

        [Fact]
        public void CheckCreateValuesTestNotValidForNamn()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

           
            String str = "";

            PersonViewModelSave PVmodel = new PersonViewModelSave();

            PVmodel.PersonNummer = "12345";
            PVmodel.ForNamn = "P";
            PVmodel.EfterNamn = "Nilsson";

            Assert.False( pv.CheckCreateValues(PVmodel, ref str) );

            Assert.True(str == " Not a valid ForNamn:");
        }

        [Fact]
        public void CheckCreateValuesTestNotMissing()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

           
            String str = "";

            PersonViewModelSave PVmodel = new PersonViewModelSave();

            PVmodel.PersonNummer = "12345";
            PVmodel.ForNamn = "Per";
            PVmodel.EfterNamn = "Nilsson";

            Assert.True( pv.CheckCreateValues(PVmodel, ref str) );

        }




    }
}
