using Athlete.ML.Model;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

namespace Athlete.DAL.AthleteContext
{
    public partial class AthleteServerContext : DbContext
    {
        //public AthleteServerContext()
        //{
        //}
            
        public AthleteServerContext(DbContextOptions<AthleteServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAthleteTestAttendees> TblAthleteTestAttendees { get; set; }
        public virtual DbSet<TblAthleteTestMaster> TblAthleteTestMaster { get; set; }
        public virtual DbSet<TblTestType> TblTestType { get; set; }
        public virtual DbSet<TblUserMaster> TblUserMaster { get; set; }
        public virtual DbSet<TblUserType> TblUserType { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=server;Database=AthleteServer;User=sa;Password=sa2016");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAthleteTestAttendees>(entity =>
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

            modelBuilder.Entity<TblAthleteTestMaster>(entity =>
            {
                entity.ToTable("tblAthleteTestMaster");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TestDate).HasColumnType("date");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblTestType>(entity =>
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

            modelBuilder.Entity<TblUserMaster>(entity =>
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

            modelBuilder.Entity<TblUserType>(entity =>
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
