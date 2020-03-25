using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SubstationManagement.Entity.Models
{
    public partial class Substation_ManagementContext : DbContext
    {

        public Substation_ManagementContext(DbContextOptions<Substation_ManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<QuanLy> QuanLy { get; set; }
        public virtual DbSet<ThamSo> ThamSo { get; set; }
        public virtual DbSet<TramBienAp> TramBienAp { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.DienThoai)
                    .HasName("PK_NhanVien_1");

                entity.Property(e => e.DienThoai).HasMaxLength(50);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<QuanLy>(entity =>
            {
                entity.HasKey(e => e.Tba);

                entity.Property(e => e.Tba)
                    .HasColumnName("TBA")
                    .ValueGeneratedNever();

                entity.Property(e => e.NhanVien)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.NhanVienNavigation)
                    .WithMany(p => p.QuanLy)
                    .HasForeignKey(d => d.NhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuanLy_NhanVien");

                entity.HasOne(d => d.TbaNavigation)
                    .WithOne(p => p.QuanLy)
                    .HasForeignKey<QuanLy>(d => d.Tba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuanLy_TramBienAp");
            });

            modelBuilder.Entity<ThamSo>(entity =>
            {
                entity.HasKey(e => e.Tba);

                entity.Property(e => e.Tba)
                    .HasColumnName("TBA")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ia).HasColumnName("IA");

                entity.Property(e => e.Ib).HasColumnName("IB");

                entity.Property(e => e.Ic).HasColumnName("IC");

                entity.Property(e => e.TCatA).HasColumnName("T_CAT_A");

                entity.Property(e => e.TCatB).HasColumnName("T_CAT_B");

                entity.Property(e => e.TCatC).HasColumnName("T_CAT_C");

                entity.Property(e => e.TMt).HasColumnName("T_MT");

                entity.Property(e => e.TTcA).HasColumnName("T_TC_A");

                entity.Property(e => e.TTcB).HasColumnName("T_TC_B");

                entity.Property(e => e.TTcC).HasColumnName("T_TC_C");

                entity.HasOne(d => d.TbaNavigation)
                    .WithOne(p => p.ThamSo)
                    .HasForeignKey<ThamSo>(d => d.Tba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThamSo_TramBienAp");
            });

            modelBuilder.Entity<TramBienAp>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GhiChu).HasColumnType("ntext");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
