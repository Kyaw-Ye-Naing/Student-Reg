using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentRegistrationSys.Models.Data
{
    public partial class StudentInfoContext : DbContext
    {
        public StudentInfoContext()
        {
        }

        public StudentInfoContext(DbContextOptions<StudentInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAcademicYear> TblAcademicYear { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }
        public virtual DbSet<TblCourse> TblCourse { get; set; }
        public virtual DbSet<TblDepartments> TblDepartments { get; set; }
        public virtual DbSet<TblPeriod> TblPeriod { get; set; }
        public virtual DbSet<TblPrerequisities> TblPrerequisities { get; set; }
        public virtual DbSet<TblResult> TblResult { get; set; }
        public virtual DbSet<TblResultDetails> TblResultDetails { get; set; }
        public virtual DbSet<TblSection> TblSection { get; set; }
        public virtual DbSet<TblSemester> TblSemester { get; set; }
        public virtual DbSet<TblStudentAccount> TblStudentAccount { get; set; }
        public virtual DbSet<TblStudentInfo> TblStudentInfo { get; set; }
        public virtual DbSet<TblSubjectCourse> TblSubjectCourse { get; set; }
        public virtual DbSet<TblTimeLimit> TblTimeLimit { get; set; }
        public virtual DbSet<TblTimeTable> TblTimeTable { get; set; }
        public virtual DbSet<TblTimeTableDetails> TblTimeTableDetails { get; set; }
        public virtual DbSet<TblYearLevel> TblYearLevel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=139.162.3.8;Initial Catalog=StudentInfo;User ID=sa;Password=admin@12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAcademicYear>(entity =>
            {
                entity.ToTable("tbl_AcademicYear");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.ToTable("tbl_Admin");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<TblCourse>(entity =>
            {
                entity.ToTable("tbl_Course");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.MajorCode).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblDepartments>(entity =>
            {
                entity.ToTable("tbl_Departments");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPeriod>(entity =>
            {
                entity.ToTable("tbl_Period");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EndTime).HasMaxLength(50);

                entity.Property(e => e.PeriodName).HasMaxLength(50);

                entity.Property(e => e.StartTime).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<TblPrerequisities>(entity =>
            {
                entity.ToTable("tbl_Prerequisities");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblResult>(entity =>
            {
                entity.ToTable("tbl_Result");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<TblResultDetails>(entity =>
            {
                entity.ToTable("tbl_ResultDetails");

                entity.Property(e => e.Grade).HasMaxLength(50);
            });

            modelBuilder.Entity<TblSection>(entity =>
            {
                entity.ToTable("tbl_Section");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblSemester>(entity =>
            {
                entity.ToTable("tbl_Semester");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblStudentAccount>(entity =>
            {
                entity.ToTable("tbl_StudentAccount");

                entity.Property(e => e.AccountId).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("date");
            });

            modelBuilder.Entity<TblStudentInfo>(entity =>
            {
                entity.ToTable("tbl_StudentInfo");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DegreeProgram).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FatherAddress).HasMaxLength(50);

                entity.Property(e => e.FatherDateOfBirth).HasColumnType("date");

                entity.Property(e => e.FatherName).HasMaxLength(50);

                entity.Property(e => e.FatherNationallity).HasMaxLength(50);

                entity.Property(e => e.FatherNativeTown).HasMaxLength(50);

                entity.Property(e => e.FatherNrc)
                    .HasColumnName("FatherNRC")
                    .HasMaxLength(50);

                entity.Property(e => e.FatherPhoneNo).HasMaxLength(50);

                entity.Property(e => e.FatherReligion).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(50);

                entity.Property(e => e.MarticulationYear).HasMaxLength(50);

                entity.Property(e => e.MarticulatonRollNo).HasMaxLength(50);

                entity.Property(e => e.MotherAddress).HasMaxLength(50);

                entity.Property(e => e.MotherDateOfBirth).HasColumnType("date");

                entity.Property(e => e.MotherName).HasMaxLength(50);

                entity.Property(e => e.MotherNationallity).HasMaxLength(50);

                entity.Property(e => e.MotherNativeTown).HasMaxLength(50);

                entity.Property(e => e.MotherNrc)
                    .HasColumnName("MotherNRC")
                    .HasMaxLength(50);

                entity.Property(e => e.MotherPhoneNo).HasMaxLength(50);

                entity.Property(e => e.MotherReligion).HasMaxLength(50);

                entity.Property(e => e.NameMyan).HasMaxLength(50);

                entity.Property(e => e.Nationality).HasMaxLength(50);

                entity.Property(e => e.Nrc)
                    .HasColumnName("NRC")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.ProvideAddress).HasMaxLength(50);

                entity.Property(e => e.ProvideName).HasMaxLength(50);

                entity.Property(e => e.ProvidePhoneNo).HasMaxLength(50);

                entity.Property(e => e.Relationship).HasMaxLength(50);

                entity.Property(e => e.Religion).HasMaxLength(50);

                entity.Property(e => e.Township).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblSubjectCourse>(entity =>
            {
                entity.ToTable("tbl_SubjectCourse");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTimeLimit>(entity =>
            {
                entity.ToTable("tbl_TimeLimit");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<TblTimeTable>(entity =>
            {
                entity.ToTable("tbl_TimeTable");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTimeTableDetails>(entity =>
            {
                entity.ToTable("tbl_TimeTableDetails");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Day).HasMaxLength(50);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblYearLevel>(entity =>
            {
                entity.ToTable("tbl_YearLevel");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
