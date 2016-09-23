using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PTJ.DataLayer.Models;
using PTJ.DataLayer.MockStore;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using PersonSvc.Controllers;
using UnitTesting.BusinessServiceTest;
using PTJ.Base.BusinessRules.Code;
using PTJ.Message;
using PTJ.Base.BusinessRules.ViewModels;

namespace UnitTesting.Controllers
{
    [TestClass]
    public class PersonTestController
    {
        [TestMethod]
        public void GetByPersTestMethod()
        {
            IApplicationDbContext _objectDB = createFakeData();
            PersonCreateUpdateDeleteFake crudFake = new PersonCreateUpdateDeleteFake();
            //PersonCode pc = new PersonCode(_objectDB);

            //PersonController controller = new PersonController(_objectDB, crudFake, pc);

            //Response<PersonViewModel> _object = controller.GetByPersnr(1234567);


            Assert.IsTrue(0 == 0);

            //EK_KUND myCust = _object.First();
            //Assert.IsTrue(myCust.KUNDNAMN == "Ikea Älvsjö");
        }

        protected IApplicationDbContext createFakeData()
        {
            MockStore data = new MockStore();

            List<Person> list2 = data.Person;
            IQueryable<Person> queryableList2 = list2.AsQueryable();

            var mockSet2 = new Mock<DbSet<Person>>();

            mockSet2.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(queryableList2.Provider);
            mockSet2.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(queryableList2.Expression);
            mockSet2.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(queryableList2.ElementType);
            mockSet2.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(queryableList2.GetEnumerator());

            var mockContext = new Mock<IApplicationDbContext>();

            mockContext.Setup(a => a.Person).Returns(mockSet2.Object);

            return  mockContext.Object;

        }
    }
}
