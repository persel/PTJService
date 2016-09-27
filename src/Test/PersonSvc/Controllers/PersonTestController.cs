using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonSvc.BusinessService;
using PersonSvc.BusinessService.Utils;
using PersonSvc.Controllers;
using PTJ.Base.BusinessRules.Code;
using PTJ.Base.BusinessRules.ViewModels;
using PTJ.DataLayer.Models;
using PTJ.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Test.PersonSvc.Controllers
{
   
    public class PersonTestController
    {

        private static DbContextOptions<ModelDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<ModelDbContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        private List<Person> createData()
        {
            List<Person> list = new List<Person>();
            Person p = new Person()
            {
                PersonNummer = "12345",
                ForNamn = "Per",
                EfterNamn = "Nilsson"
            };

            list.Add(p);

            Person p2 = new Person()
            {
                PersonNummer = "12345678",
                ForNamn = "Per2",
                EfterNamn = "Nilsson2"
            };
            list.Add(p2);

            return list;

        }


        [Fact]
        public void GetByPersnrTest()
        {

            var options = CreateNewContextOptions();

            // Run the test against one instance of the context
            using (var context = new  ModelDbContext(options))
            {

                List<Person> list = createData();

                foreach (var p in list)
                {
                    context.Person.Add(p);
                }

                context.SaveChanges();

                PersonCreateUpdateDeleteFake crudFake = new PersonCreateUpdateDeleteFake();
                PersonController controller = new PersonController(context, crudFake);

                var response = controller.GetByPersnr(12345);

                Assert.True(response.success == "true");

                Assert.True(response.result.First().Person.ForNamn == "Per");

            }

        }


        [Fact]
        public void CreateTest()
        {

            var options = CreateNewContextOptions();

            // Run the test against one instance of the context
            using (var context = new ModelDbContext(options))
            {

                PersonViewModel PVmodel = new PersonViewModel();
                //String str = "";

                PVmodel.Person = new Person()
                {
                    PersonNummer = "12345",
                    ForNamn = "Per",
                    EfterNamn = "Nilsson"
                };


                PersonCode pc = new PersonCode(context);
                PersonCreateUpdateDeleteFake crudFake = new PersonCreateUpdateDeleteFake();
                PersonController controller = new PersonController(context, crudFake);
                
                var response = controller.Create(PVmodel);

                Assert.True(response.success == "true");
            }

        }

        [Theory]
        [InlineData("Per")]
        [InlineData("Nisse")]
        [InlineData("qsd1234")]
        public void CreateTestDiffFirstName(string value)
        {

            var options = CreateNewContextOptions();

            // Run the test against one instance of the context
            using (var context = new ModelDbContext(options))
            {

                PersonViewModel PVmodel = new PersonViewModel();
                //String str = "";

                PVmodel.Person = new Person()
                {
                    PersonNummer = "12345",
                    ForNamn = value,
                    EfterNamn = "Nilsson"
                };


                PersonCode pc = new PersonCode(context);
                PersonCreateUpdateDeleteFake crudFake = new PersonCreateUpdateDeleteFake();
                PersonController controller = new PersonController(context, crudFake);

                var response = controller.Create(PVmodel);

                Assert.True(response.success == "true");
       
            }

        }









    }
}
