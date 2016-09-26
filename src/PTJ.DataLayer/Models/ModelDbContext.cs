using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PTJ.DataLayer.Models;

namespace PTJ.DataLayer.Models
{

    public interface IApplicationDbContext
    {
        DbSet<Person> Person { get; set; }

        DbSet<Adress> Adress { get; set; }
        DbSet<AdressTyp> AdressTyp { get; set; }
        DbSet<AdressVariant> AdressVariant { get; set; }
        DbSet<GatuAdress> GatuAdress { get; set; }
        DbSet<Mail> Mail { get; set; }
        DbSet<Organisation> Organisation { get; set; }
        DbSet<OrganisationAdress> OrganisationAdress { get; set; }
       
        DbSet<PersonAdress> PersonAdress { get; set; }
        DbSet<PersonAnnanPerson> PersonAnnanPerson { get; set; }
        DbSet<PersonAnstalld> PersonAnstalld { get; set; }
        DbSet<PersonKonsult> PersonKonsult { get; set; }
        DbSet<PersonPatient> PersonPatient { get; set; }
        DbSet<PersonSjukHalsovardsPersonal> PersonSjukHalsovardsPersonal { get; set; }
        DbSet<Telefon> Telefon { get; set; }
        //object Database { get; set; }

        int SaveChanges();
     
    }

    public class ModelDbContext : DbContext//, IApplicationDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=ds1ptjsql03;Database=PTJ_Operational_Db;Trusted_Connection=True;");
        }
        public ModelDbContext(DbContextOptions<ModelDbContext> options)
            : base(options)
        { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Adress>(entity =>
        //    {
        //        entity.ToTable("Adress", "Adress");

        //        entity.HasIndex(e => e.AdressTypFkid)
        //            .HasName("IXFK_Adress_AdressTyp_02");

        //        entity.HasIndex(e => e.AdressVariantFkid)
        //            .HasName("IXFK_Adress_AdressVariant");

        //        entity.Property(e => e.Id).ValueGeneratedNever();

        //        entity.Property(e => e.AdressTypFkid).HasColumnName("AdressTyp_FKID");

        //        entity.Property(e => e.AdressVariantFkid).HasColumnName("AdressVariant_FKID");

        //        entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

        //        entity.Property(e => e.UpdateradAv)
        //            .IsRequired()
        //            .HasMaxLength(100);

        //        entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");
        //    });


        //}

        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<AdressTyp> AdressTyp { get; set; }
        public virtual DbSet<AdressVariant> AdressVariant { get; set; }
        public virtual DbSet<GatuAdress> GatuAdress { get; set; }
        public virtual DbSet<Mail> Mail { get; set; }
        public virtual DbSet<Organisation> Organisation { get; set; }
        public virtual DbSet<OrganisationAdress> OrganisationAdress { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAdress> PersonAdress { get; set; }
        public virtual DbSet<PersonAnnanPerson> PersonAnnanPerson { get; set; }
        public virtual DbSet<PersonAnstalld> PersonAnstalld { get; set; }
        public virtual DbSet<PersonKonsult> PersonKonsult { get; set; }
        public virtual DbSet<PersonPatient> PersonPatient { get; set; }
        public virtual DbSet<PersonSjukHalsovardsPersonal> PersonSjukHalsovardsPersonal { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }
    }

  
}
