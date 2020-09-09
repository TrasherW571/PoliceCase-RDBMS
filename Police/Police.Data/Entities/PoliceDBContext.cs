using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Police.Data.Entities
{
    public partial class PoliceDBContext : DbContext
    {
        public PoliceDBContext()
        {
        }

        public PoliceDBContext(DbContextOptions<PoliceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<ArrestingReport> ArrestingReport { get; set; }
        public virtual DbSet<AutopsyReport> AutopsyReport { get; set; }
        public virtual DbSet<CaseFolder> CaseFolder { get; set; }
        public virtual DbSet<Crime> Crime { get; set; }
        public virtual DbSet<Criminal> Criminal { get; set; }
        public virtual DbSet<Evidence> Evidence { get; set; }
        public virtual DbSet<InvolvedPersons> InvolvedPersons { get; set; }
        public virtual DbSet<Officer> Officer { get; set; }
        public virtual DbSet<PoliceReport> PoliceReport { get; set; }
        public virtual DbSet<Victim> Victim { get; set; }
        public virtual DbSet<Witness> Witness { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address", "Police");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ArrestingReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__Arrestin__D5BD48E5125E210D");

                entity.ToTable("ArrestingReport", "Police");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.CrimeId).HasColumnName("CrimeID");

                entity.Property(e => e.CriminalId).HasColumnName("CriminalID");

                entity.HasOne(d => d.Crime)
                    .WithMany(p => p.ArrestingReport)
                    .HasForeignKey(d => d.CrimeId);

                entity.HasOne(d => d.Criminal)
                    .WithMany(p => p.ArrestingReport)
                    .HasForeignKey(d => d.CriminalId);
            });

            modelBuilder.Entity<AutopsyReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__AutopsyR__D5BD48E540F72DD8");

                entity.ToTable("AutopsyReport", "Police");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.CauseOfDeath)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MannerOfDeath)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.VictimId).HasColumnName("VictimID");

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.AutopsyReport)
                    .HasForeignKey(d => d.CaseId);

                entity.HasOne(d => d.ExaminerNavigation)
                    .WithMany(p => p.AutopsyReport)
                    .HasForeignKey(d => d.Examiner)
                    .HasConstraintName("FK_AutopsyReport_Officer_OfficerID");

                entity.HasOne(d => d.Victim)
                    .WithMany(p => p.AutopsyReport)
                    .HasForeignKey(d => d.VictimId);
            });

            modelBuilder.Entity<CaseFolder>(entity =>
            {
                entity.HasKey(e => e.CaseId)
                    .HasName("PK__CaseFold__6CAE526C2713E1A4");

                entity.ToTable("CaseFolder", "Police");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.ArrestingReportId).HasColumnName("ArrestingReportID");

                entity.Property(e => e.PoliceReportId).HasColumnName("PoliceReportID");

                entity.HasOne(d => d.ArrestingReport)
                    .WithMany(p => p.CaseFolder)
                    .HasForeignKey(d => d.ArrestingReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaseFolder_ArrestingReport_ReportID");

                entity.HasOne(d => d.PoliceReport)
                    .WithMany(p => p.CaseFolder)
                    .HasForeignKey(d => d.PoliceReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CaseFolder_PoliceReport_ReportID");
            });

            modelBuilder.Entity<Crime>(entity =>
            {
                entity.ToTable("Crime", "Police");

                entity.Property(e => e.CrimeId).HasColumnName("CrimeID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Criminal>(entity =>
            {
                entity.ToTable("Criminal", "Police");

                entity.Property(e => e.CriminalId).HasColumnName("CriminalID");

                entity.Property(e => e.BodyMarks).HasMaxLength(4000);

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Occupation).HasMaxLength(200);

                entity.Property(e => e.Portrait).HasColumnType("image");

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.CurrentAddressNavigation)
                    .WithMany(p => p.Criminal)
                    .HasForeignKey(d => d.CurrentAddress)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Criminal_Address_AddressID");
            });

            modelBuilder.Entity<Evidence>(entity =>
            {
                entity.ToTable("Evidence", "Police");

                entity.Property(e => e.EvidenceId).HasColumnName("EvidenceID");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Case)
                    .WithMany(p => p.Evidence)
                    .HasForeignKey(d => d.CaseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<InvolvedPersons>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InvolvedPersons", "Police");

                entity.Property(e => e.CaseId).HasColumnName("CaseID");

                entity.Property(e => e.WitnessId).HasColumnName("WitnessID");

                entity.HasOne(d => d.Case)
                    .WithMany()
                    .HasForeignKey(d => d.CaseId);

                entity.HasOne(d => d.Witness)
                    .WithMany()
                    .HasForeignKey(d => d.WitnessId);
            });

            modelBuilder.Entity<Officer>(entity =>
            {
                entity.ToTable("Officer", "Police");

                entity.Property(e => e.OfficerId).HasColumnName("OfficerID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Rank)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Officer)
                    .HasForeignKey(d => d.AddressId);
            });

            modelBuilder.Entity<PoliceReport>(entity =>
            {
                entity.HasKey(e => e.ReportId)
                    .HasName("PK__PoliceRe__D5BD48E5AABD5217");

                entity.ToTable("PoliceReport", "Police");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");

                entity.Property(e => e.CrimeId).HasColumnName("CrimeID");

                entity.Property(e => e.Narrative)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Crime)
                    .WithMany(p => p.PoliceReport)
                    .HasForeignKey(d => d.CrimeId);

                entity.HasOne(d => d.CrimeLocationNavigation)
                    .WithMany(p => p.PoliceReport)
                    .HasForeignKey(d => d.CrimeLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PoliceReport_Address_AddressID");

                entity.HasOne(d => d.ReportingOfficerNavigation)
                    .WithMany(p => p.PoliceReport)
                    .HasForeignKey(d => d.ReportingOfficer)
                    .HasConstraintName("FK_PoliceReport_Officer_OfficerID");
            });

            modelBuilder.Entity<Victim>(entity =>
            {
                entity.ToTable("Victim", "Police");

                entity.Property(e => e.VictimId).HasColumnName("VictimID");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Witness>(entity =>
            {
                entity.ToTable("Witness", "Police");

                entity.Property(e => e.WitnessId).HasColumnName("WitnessID");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
