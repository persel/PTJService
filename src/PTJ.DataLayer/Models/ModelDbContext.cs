using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PTJ.DataLayer.Models;

namespace PTJ.DataLayer.Models
{
    public class ModelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=ds1ptjsql03;Database=PTJ_Operational_Db;Trusted_Connection=True;");
        }
        public ModelDbContext(DbContextOptions<ModelDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>(entity =>
            {
                entity.ToTable("Adress", "Adress");

                entity.HasIndex(e => e.AdressTypFkid)
                    .HasName("IXFK_Adress_AdressTyp_02");

                entity.HasIndex(e => e.AdressVariantFkid)
                    .HasName("IXFK_Adress_AdressVariant");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdressTypFkid).HasColumnName("AdressTyp_FKID");

                entity.Property(e => e.AdressVariantFkid).HasColumnName("AdressVariant_FKID");

                entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

                entity.Property(e => e.UpdateradAv)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

                //entity.HasOne(d => d.AdressTypFk)
                //    .WithMany(p => p.Adress)
                //    .HasForeignKey(d => d.AdressTypFkid)
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .HasConstraintName("FK_Adress_AdressTyp_02");

                //entity.HasOne(d => d.AdressVariantFk)
                //    .WithMany(p => p.Adress)
                //    .HasForeignKey(d => d.AdressVariantFkid)
                //    .OnDelete(DeleteBehavior.Restrict)
                //    .HasConstraintName("FK_Adress_AdressVariant");
            });

            //modelBuilder.Entity<AdressTyp>(entity =>
            //{
            //    entity.ToTable("AdressTyp", "Adress");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.Typ)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<AdressVariant>(entity =>
            //{
            //    entity.ToTable("AdressVariant", "Adress");

            //    entity.HasIndex(e => e.AdressTypFkid)
            //        .HasName("IXFK_AdressVariant_AdressTyp");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.AdressTypFkid).HasColumnName("AdressTyp_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.Property(e => e.Variant)
            //        .IsRequired()
            //        .HasMaxLength(255);

            //    entity.HasOne(d => d.AdressTypFk)
            //        .WithMany(p => p.AdressVariant)
            //        .HasForeignKey(d => d.AdressTypFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_AdressVariant_AdressTyp");
            //});

            //modelBuilder.Entity<GatuAdress>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.AdressFkid })
            //        .HasName("PK_GatuAdress");

            //    entity.ToTable("GatuAdress", "Adress");

            //    entity.HasIndex(e => e.AdressFkid)
            //        .HasName("IXFK_GatuAdress_Adress_04");

            //    entity.HasIndex(e => e.Id)
            //        .HasName("IXFK_GatuAdress_Adress");

            //    entity.Property(e => e.AdressFkid).HasColumnName("Adress_FKID");

            //    entity.Property(e => e.AdressRad1).HasMaxLength(255);

            //    entity.Property(e => e.AdressRad2).HasMaxLength(255);

            //    entity.Property(e => e.AdressRad3).HasMaxLength(255);

            //    entity.Property(e => e.AdressRad4).HasMaxLength(255);

            //    entity.Property(e => e.AdressRad5).HasMaxLength(255);

            //    entity.Property(e => e.Land).HasMaxLength(255);

            //    entity.Property(e => e.Postnummer).HasColumnType("numeric");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.Stad)
            //        .IsRequired()
            //        .HasMaxLength(255);

            //    entity.Property(e => e.UpdateradAv).HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.AdressFk)
            //        .WithMany(p => p.GatuAdress)
            //        .HasForeignKey(d => d.AdressFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_GatuAdress_Adress");
            //});

            //modelBuilder.Entity<Mail>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.AdressFkid })
            //        .HasName("PK_Mail");

            //    entity.ToTable("Mail", "Adress");

            //    entity.HasIndex(e => e.AdressFkid)
            //        .HasName("IXFK_Mail_Adress_02");

            //    entity.Property(e => e.AdressFkid).HasColumnName("Adress_FKID");

            //    entity.Property(e => e.MailAdress)
            //        .IsRequired()
            //        .HasColumnType("varchar(255)");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.AdressFk)
            //        .WithMany(p => p.Mail)
            //        .HasForeignKey(d => d.AdressFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Mail_Adress_02");
            //});

            //modelBuilder.Entity<Organisation>(entity =>
            //{
            //    entity.ToTable("Organisation", "Organisation");

            //    entity.HasIndex(e => e.IngarIorganisation)
            //        .HasName("IXFK_Organisation_Organisation_02");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.IngarIorganisation).HasColumnName("IngarIOrganisation");

            //    entity.Property(e => e.OrganisationsId)
            //        .IsRequired()
            //        .HasColumnType("varchar(50)");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpDateradDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.HasOne(d => d.IngarIorganisationNavigation)
            //        .WithMany(p => p.InverseIngarIorganisationNavigation)
            //        .HasForeignKey(d => d.IngarIorganisation)
            //        .HasConstraintName("FK_Organisation_Organisation");
            //});

            //modelBuilder.Entity<OrganisationAdress>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.OrganisationFkid, e.AdressFkid })
            //        .HasName("PK_Organisation_Adress");

            //    entity.ToTable("Organisation_Adress", "Adress");

            //    entity.HasIndex(e => e.AdressFkid)
            //        .HasName("IXFK_Organisation_Adress_Adress");

            //    entity.HasIndex(e => e.OrganisationFkid)
            //        .HasName("IXFK_Organisation_Adress_Organisation");

            //    entity.Property(e => e.OrganisationFkid).HasColumnName("Organisation_FKID");

            //    entity.Property(e => e.AdressFkid).HasColumnName("Adress_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.AdressFk)
            //        .WithMany(p => p.OrganisationAdress)
            //        .HasForeignKey(d => d.AdressFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Organisation_Adress_Adress");

            //    entity.HasOne(d => d.OrganisationFk)
            //        .WithMany(p => p.OrganisationAdress)
            //        .HasForeignKey(d => d.OrganisationFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Organisation_Adress_Organisation");
            //});

            //modelBuilder.Entity<Person>(entity =>
            //{
            //    entity.ToTable("Person", "Person");

            //    entity.Property(e => e.Id).ValueGeneratedNever();

            //    entity.Property(e => e.EfterNamn)
            //        .IsRequired()
            //        .HasMaxLength(255);

            //    entity.Property(e => e.ForNamn)
            //        .IsRequired()
            //        .HasMaxLength(255);

            //    entity.Property(e => e.MellanNamn).HasMaxLength(255);

            //    entity.Property(e => e.PersonNummer)
            //        .IsRequired()
            //        .HasColumnType("varchar(12)");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UppdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UppdateradDatum).HasColumnType("datetime");
            //});

            //modelBuilder.Entity<PersonAdress>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.PersonFkid, e.AdressFkid })
            //        .HasName("PK_Person_Adress");

            //    entity.ToTable("Person_Adress", "Adress");

            //    entity.HasIndex(e => e.AdressFkid)
            //        .HasName("IXFK_Person_Adress_Adress");

            //    entity.HasIndex(e => e.PersonFkid)
            //        .HasName("IXFK_Person_Adress_Person");

            //    entity.Property(e => e.PersonFkid).HasColumnName("Person_FKID");

            //    entity.Property(e => e.AdressFkid).HasColumnName("Adress_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.AdressFk)
            //        .WithMany(p => p.PersonAdress)
            //        .HasForeignKey(d => d.AdressFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Person_Adress_Adress");

            //    entity.HasOne(d => d.PersonFk)
            //        .WithMany(p => p.PersonAdress)
            //        .HasForeignKey(d => d.PersonFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Person_Adress_Person");
            //});

            //modelBuilder.Entity<PersonAnnanPerson>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.PersonFkid, e.AnnanPersonFkid })
            //        .HasName("PK_Person_AnnanPerson");

            //    entity.ToTable("Person_AnnanPerson", "Person");

            //    entity.HasIndex(e => e.PersonFkid)
            //        .HasName("IXFK_Person_AnnanPerson_Person");

            //    entity.Property(e => e.PersonFkid).HasColumnName("Person_FKID");

            //    entity.Property(e => e.AnnanPersonFkid).HasColumnName("AnnanPerson_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.PersonFk)
            //        .WithMany(p => p.PersonAnnanPerson)
            //        .HasForeignKey(d => d.PersonFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Person_AnnanPerson_Person");
            //});

            //modelBuilder.Entity<PersonAnstalld>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.PersonFkid, e.AnstalldFkid })
            //        .HasName("PK_Person_Anställd");

            //    entity.ToTable("Person_Anstalld", "Person");

            //    entity.HasIndex(e => e.PersonFkid)
            //        .HasName("IXFK_Person_Anställd_Person");

            //    entity.Property(e => e.PersonFkid).HasColumnName("Person_FKID");

            //    entity.Property(e => e.AnstalldFkid).HasColumnName("Anstalld_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.PersonFk)
            //        .WithMany(p => p.PersonAnstalld)
            //        .HasForeignKey(d => d.PersonFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Person_Anställd_Person");
            //});

            //modelBuilder.Entity<PersonKonsult>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.PersonFkid, e.KonsultFkid })
            //        .HasName("PK_Person_Konsult");

            //    entity.ToTable("Person_Konsult", "Person");

            //    entity.HasIndex(e => e.PersonFkid)
            //        .HasName("IXFK_Person_Konsult_Person");

            //    entity.Property(e => e.PersonFkid).HasColumnName("Person_FKID");

            //    entity.Property(e => e.KonsultFkid).HasColumnName("Konsult_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.PersonFk)
            //        .WithMany(p => p.PersonKonsult)
            //        .HasForeignKey(d => d.PersonFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Person_Konsult_Person");
            //});

            //modelBuilder.Entity<PersonPatient>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.PersonFkid, e.PatientFkid })
            //        .HasName("PK_Person_Patient");

            //    entity.ToTable("Person_Patient", "Person");

            //    entity.HasIndex(e => e.PersonFkid)
            //        .HasName("IXFK_Person_Patient_Person");

            //    entity.Property(e => e.PersonFkid).HasColumnName("Person_FKID");

            //    entity.Property(e => e.PatientFkid).HasColumnName("Patient_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.PersonFk)
            //        .WithMany(p => p.PersonPatient)
            //        .HasForeignKey(d => d.PersonFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Person_Patient_Person");
            //});

            //modelBuilder.Entity<PersonSjukHälsovårdsPersonal>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.PersonFkid, e.SjukHalsovardsPersonalFkid })
            //        .HasName("PK_Person_Sjuk_Hälsovårds_Personal");

            //    entity.ToTable("Person_Sjuk_Hälsovårds_Personal", "Person");

            //    entity.HasIndex(e => e.PersonFkid)
            //        .HasName("IXFK_Person_Sjuk_Hälsovårds_Personal_Person");

            //    entity.Property(e => e.PersonFkid).HasColumnName("Person_FKID");

            //    entity.Property(e => e.SjukHalsovardsPersonalFkid).HasColumnName("Sjuk_Halsovards_Personal_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.PersonFk)
            //        .WithMany(p => p.PersonSjukHälsovårdsPersonal)
            //        .HasForeignKey(d => d.PersonFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Person_Sjuk_Hälsovårds_Personal_Person");
            //});

            //modelBuilder.Entity<Telefon>(entity =>
            //{
            //    entity.HasKey(e => new { e.Id, e.AdressFkid })
            //        .HasName("PK_Telefon");

            //    entity.ToTable("Telefon", "Adress");

            //    entity.HasIndex(e => e.AdressFkid)
            //        .HasName("IXFK_Telefon_Adress_02");

            //    entity.Property(e => e.AdressFkid).HasColumnName("Adress_FKID");

            //    entity.Property(e => e.SkapadDatum).HasColumnType("datetime");

            //    entity.Property(e => e.TelefonNummer).HasColumnType("numeric");

            //    entity.Property(e => e.UpdateradAv)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.UpdateradDatum).HasColumnType("datetime");

            //    entity.HasOne(d => d.AdressFk)
            //        .WithMany(p => p.Telefon)
            //        .HasForeignKey(d => d.AdressFkid)
            //        .OnDelete(DeleteBehavior.Restrict)
            //        .HasConstraintName("FK_Telefon_Adress_02");
            //});
        }

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
        //public virtual DbSet<PersonSjukHälsovårdsPersonal> PersonSjukHälsovårdsPersonal { get; set; }
        public virtual DbSet<Telefon> Telefon { get; set; }
    }

  
}
