using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CanKT.Models
{
    public partial class CanDBContext : DbContext
    {
        public CanDBContext()
            : base("name=CanDBContext")
        {
        }

        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<DonViTinh> DonViTinhs { get; set; }
        public virtual DbSet<Kho> Khoes { get; set; }
        public virtual DbSet<MaTienTe> MaTienTes { get; set; }
        public virtual DbSet<MayXay> MayXays { get; set; }
        public virtual DbSet<NhomThanhPham> NhomThanhPhams { get; set; }
        public virtual DbSet<NVKH> NVKHs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TramCan> TramCans { get; set; }
        public virtual DbSet<XeXuc> XeXucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonVi>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .Property(e => e.maDonViTinh)
                .IsUnicode(false);

            modelBuilder.Entity<Kho>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<Kho>()
                .Property(e => e.maKho)
                .IsUnicode(false);

            modelBuilder.Entity<MaTienTe>()
                .Property(e => e.maTienTe1)
                .IsUnicode(false);

            modelBuilder.Entity<MayXay>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<MayXay>()
                .Property(e => e.maMayXay)
                .IsUnicode(false);

            modelBuilder.Entity<NhomThanhPham>()
                .Property(e => e.maNhom)
                .IsUnicode(false);

            modelBuilder.Entity<NVKH>()
                .Property(e => e.maNVKH)
                .IsUnicode(false);

            modelBuilder.Entity<NVKH>()
                .Property(e => e.tenNVKH)
                .IsUnicode(false);

            modelBuilder.Entity<NVKH>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NVKH>()
                .Property(e => e.maSoThue)
                .IsUnicode(false);

            modelBuilder.Entity<NVKH>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maThanhPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maDonViTinh)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maKho)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maThue)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .HasMany(e => e.NVKHs)
                .WithOptional(e => e.TaiKhoan)
                .HasForeignKey(e => e.tenDangNhap);

            modelBuilder.Entity<TramCan>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<TramCan>()
                .Property(e => e.maTramCan)
                .IsUnicode(false);

            modelBuilder.Entity<XeXuc>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<XeXuc>()
                .Property(e => e.maXeXuc)
                .IsUnicode(false);
        }
    }
}
