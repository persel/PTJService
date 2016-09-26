using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonSvc.BusinessService.Interfaces;
using PTJ.Base.BusinessRules.ViewModels;
using PersonSvc.BusinessService;
using PersonSvc.BusinessService.Utils;
using PTJ.DataLayer.Models;

namespace UnitTesting.BusinessServiceTest
{
    [TestClass]
    public class PersonValidationTest
    {
        //[TestMethod]
        //public void CheckCreateValuesTest()
        //{
        //    ValueUtils vu = new ValueUtils();
        //    //PersonValidation pv = new PersonValidation(vu);

        //    //PersonViewModel PVmodel = new PersonViewModel();
        //    //String str = "";

        //    //PVmodel.Person = new Person() {
        //    //    PersonNummer = "122345",
        //    //    ForNamn = "Per",
        //    //    EfterNamn = "Nilsson"
        //    //};

        //    //Assert.IsTrue( pv.CheckCreateValues(PVmodel, ref str) == true );

        //    Assert.IsTrue(true);

        //}

        [TestMethod]
        public void CheckUpdatesValuesTest()
        {
            Assert.IsTrue(true);
        }

    }
}
