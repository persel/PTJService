
using PersonSvc.BusinessService;
using PersonSvc.BusinessService.Utils;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;
using System;
using Xunit;

namespace Test
{
    public class PersonValidationTest
    {
    
        [Fact]
        public void CheckCreateValuesTest()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

            PersonViewModel PVmodel = new PersonViewModel();
            String str = "";

            PVmodel.Person = new Person()
            {
                PersonNummer = "122345",
                ForNamn = "Per",
                EfterNamn = "Nilsson"
            };

            Assert.True( pv.CheckCreateValues(PVmodel, ref str) == true );

        }

        [Fact]
        public void CheckCreateValuesTestNotValidPersnr()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

            PersonViewModel PVmodel = new PersonViewModel();
            String str = "";

            PVmodel.Person = new Person()
            {
                PersonNummer = "12",
                ForNamn = "Per",
                EfterNamn = "Nilsson"
            };
            
            Assert.True(pv.CheckCreateValues(PVmodel, ref str) == false);

            Assert.True(str == "Not a valid PersonNummer:");

        }

        [Fact]
        public void CheckCreateValuesTestNotValidForNamn()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

            PersonViewModel PVmodel = new PersonViewModel();
            String str = "";

            PVmodel.Person = new Person()
            {
                PersonNummer = "12345678",
                ForNamn = "P",
                EfterNamn = "Nilsson"
            };

            Assert.False( pv.CheckCreateValues(PVmodel, ref str) );

            Assert.True(str == " Not a valid ForNamn:");
        }

        [Fact]
        public void CheckCreateValuesTestNotMissingValues()
        {
            ValueUtils vu = new ValueUtils();
            PersonValidation pv = new PersonValidation(vu);

            PersonViewModel PVmodel = new PersonViewModel();
            String str = "";

            PVmodel.Person = new Person()
            {
                PersonNummer = String.Empty,
                ForNamn = "P",
                EfterNamn = "Nilsson"
            };

            Assert.False( pv.CheckCreateValues(PVmodel, ref str) );

        }




    }
}
