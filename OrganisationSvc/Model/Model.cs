using Microsoft.EntityFrameworkCore;
using PTJ.DataLayer.Models;

namespace OrganisationSvc.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        { }

        public virtual DbSet<Person> Person { get; set; }
        public DbSet<Adress> Adress { get; set; }

        public DbSet<PersonAdress> PersonAdress { get; set; }

        public DbSet<Organisation> Organisation { get; set; }


    }


}
