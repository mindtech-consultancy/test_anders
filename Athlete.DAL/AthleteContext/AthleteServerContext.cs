using Athlete.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Athlete.DAL.AthleteContext
{
    public partial class AthleteServerContext : DbContext
    {
        public AthleteServerContext(DbContextOptions<AthleteServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AthleteTestAttendeesModel> TblAthleteTestAttendees { get; set; }
        public virtual DbSet<AthleteTestMasterModel> TblAthleteTestMaster { get; set; }
        public virtual DbSet<TestTypeModel> TblTestType { get; set; }
        public virtual DbSet<UserMasterModel> TblUserMaster { get; set; }
        public virtual DbSet<UserTypeModel> TblUserType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AthleteTestAttendeesModel>(entity =>
            {
                entity.ToTable("tblAthleteTestAttendees");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TestAttributeValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AthleteTestMasterModel>(entity =>
            {
                entity.ToTable("tblAthleteTestMaster");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TestDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TestTypeModel>(entity =>
            {
                entity.ToTable("tblTestType");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TestAttribute)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TestType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserMasterModel>(entity =>
            {
                entity.ToTable("tblUserMaster");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<UserTypeModel>(entity =>
            {
                entity.ToTable("tblUserType");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
