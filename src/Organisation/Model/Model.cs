﻿using Microsoft.EntityFrameworkCore;
using PTJ.DataLayer;

namespace Organisation.Model
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        { }

        public virtual DbSet<Person> Person { get; set; }
        public DbSet<Adress> Adress { get; set; }

        public DbSet<PersonAdress> PersonAdress { get; set; }
    }

  
}
