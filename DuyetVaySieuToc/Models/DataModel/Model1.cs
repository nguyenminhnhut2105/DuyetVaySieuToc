namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CAPQUYEN> CAPQUYENs { get; set; }
        public virtual DbSet<LOAINGUOIDUNG> LOAINGUOIDUNGs { get; set; }
        public virtual DbSet<NGHIEPVU> NGHIEPVUs { get; set; }
        public virtual DbSet<NGUOIDUNG> NGUOIDUNGs { get; set; }
        public virtual DbSet<NGUOIDUNGVAY> NGUOIDUNGVAYs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<THONGBAO> THONGBAOs { get; set; }
        public virtual DbSet<TINHTRANG> TINHTRANGs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LOAINGUOIDUNG>()
                .HasMany(e => e.NGUOIDUNGs)
                .WithRequired(e => e.LOAINGUOIDUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGHIEPVU>()
                .Property(e => e.MANGIEPVU)
                .IsUnicode(false);

            modelBuilder.Entity<NGHIEPVU>()
                .HasMany(e => e.QUYENs)
                .WithRequired(e => e.NGHIEPVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NGUOIDUNG>()
                .HasMany(e => e.CAPQUYENs)
                .WithRequired(e => e.NGUOIDUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.MANGIEPVU)
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.TENQUYEN)
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .HasMany(e => e.CAPQUYENs)
                .WithRequired(e => e.QUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THONGBAO>()
                .HasMany(e => e.NGUOIDUNGVAYs)
                .WithRequired(e => e.THONGBAO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TINHTRANG>()
                .HasMany(e => e.NGUOIDUNGVAYs)
                .WithRequired(e => e.TINHTRANG1)
                .WillCascadeOnDelete(false);
        }
    }
}
