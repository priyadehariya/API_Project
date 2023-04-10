using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace astoriaTrainingAPI.Models
{
    public partial class astoriaTraining80Context : DbContext
    {
        

        public astoriaTraining80Context(DbContextOptions<astoriaTraining80Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AllowanceMaster> AllowanceMaster { get; set; }
        public virtual DbSet<CompanyMaster> CompanyMaster { get; set; }
        public virtual DbSet<DesignationMaster> DesignationMaster { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public virtual DbSet<EmployeeAllowanceDetail> EmployeeAllowanceDetail { get; set; }
        public virtual DbSet<EmployeeAttendence> EmployeeAttendence { get; set; }
        public object UserInfo { get; internal set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //  if (!optionsBuilder.IsConfigured)
        //  {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        // optionsBuilder.UseSqlServer("Server=ASTORIA-LT44;Database=astoriaTraining8.0;User Id=sa;Password=pass123;");
        // }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllowanceMaster>(entity =>
            {
                entity.HasKey(e => e.AllowanceId)
                    .HasName("PK__Allowanc__7B12D041D749258F");

                entity.Property(e => e.AllowanceId)
                    .HasColumnName("AllowanceID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AllowanceDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AllowanceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompanyMaster>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__CompanyM__2D971C4C3F0A9AAD");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyDescription)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesignationId)
                    .HasName("PK__Designat__BABD603E9D0EDF03");

                entity.Property(e => e.DesignationId)
                    .HasColumnName("DesignationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DesignationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmlpooyeeMaster>(entity =>
            {
                entity.HasKey(e => e.EmployeeKey)
                    .HasName("PK__Emlpooye__8749E50AAEB2B4CB");

                entity.Property(e => e.EmployeeKey).ValueGeneratedNever();

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.EmpCompanyId).HasColumnName("EmpCompanyID");

                entity.Property(e => e.EmpDesignationId).HasColumnName("EmpDesignationID");

                entity.Property(e => e.EmpFirstName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpGender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpHourlySalaryRate).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.EmpJoiningDate).HasColumnType("datetime");

                entity.Property(e => e.EmpLastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpResignationDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("EmployeeID")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                //entity.HasOne(d => d.EmpCompany)
                //    .WithMany(p => p.EmployeeMaster)
                //    .HasForeignKey(d => d.EmpCompanyId)
                //    .HasConstraintName("FK__Emlpooyee__EmpCo__3C69FB99");

                //entity.HasOne(d => d.EmpDesignation)
                //    .WithMany(p => p.EmployeeMaster)
                //    .HasForeignKey(d => d.EmpDesignationId)
                //    .HasConstraintName("FK__Emlpooyee__EmpDe__3D5E1FD2");
            });

            modelBuilder.Entity<EmployeeAllowanceDetail>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeKey, e.AllowanceId, e.ClockDate })
                    .HasName("PK__Employee__BDFD953F6C5B1776");

                entity.Property(e => e.AllowanceId).HasColumnName("AllowanceID");

                entity.Property(e => e.ClockDate).HasColumnType("date");

                entity.Property(e => e.AllowanceAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Allowance)
                    .WithMany(p => p.EmployeeAllowanceDetail)
                    .HasForeignKey(d => d.AllowanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__Allow__440B1D61");

                entity.HasOne(d => d.EmployeeKeyNavigation)
                    .WithMany(p => p.EmployeeAllowanceDetail)
                    .HasForeignKey(d => d.EmployeeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__Emplo__4316F928");
            });

            modelBuilder.Entity<EmployeeAttendence>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeKey, e.ClockDate })
                    .HasName("PK__Employee__571C3619797048FD");

                entity.Property(e => e.ClockDate).HasColumnType("date");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.TimeOut).HasColumnType("datetime");

                entity.Property(e => e.Timein).HasColumnType("datetime");

                entity.HasOne(d => d.EmployeeKeyNavigation)
                    .WithMany(p => p.EmployeeAttendence)
                    .HasForeignKey(d => d.EmployeeKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EmployeeA__Emplo__46E78A0C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
