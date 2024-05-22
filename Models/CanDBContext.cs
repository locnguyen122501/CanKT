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
        public virtual DbSet<Gia> Gias { get; set; }
        public virtual DbSet<HanMucCongNo> HanMucCongNoes { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<Kho> Khoes { get; set; }
        public virtual DbSet<MaTienTe> MaTienTes { get; set; }
        public virtual DbSet<MayXay> MayXays { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhapXuat> NhapXuats { get; set; }
        public virtual DbSet<NhomThanhPham> NhomThanhPhams { get; set; }
        public virtual DbSet<PhieuThu> PhieuThus { get; set; }
        public virtual DbSet<SaLan> SaLans { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TramCan> TramCans { get; set; }
        public virtual DbSet<Xe> Xes { get; set; }
        public virtual DbSet<XeXuc> XeXucs { get; set; }
        public virtual DbSet<ThongKe> ThongKes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonVi>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<DonViTinh>()
                .Property(e => e.maDonViTinh)
                .IsUnicode(false);

            modelBuilder.Entity<Gia>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<Gia>()
                .Property(e => e.maDonGia)
                .IsUnicode(false);

            modelBuilder.Entity<Gia>()
                .Property(e => e.maThanhPham)
                .IsUnicode(false);

            modelBuilder.Entity<Gia>()
                .Property(e => e.maKho)
                .IsUnicode(false);

            modelBuilder.Entity<Gia>()
                .Property(e => e.maNgoaiTe)
                .IsUnicode(false);

            modelBuilder.Entity<Gia>()
                .Property(e => e.donGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HanMucCongNo>()
                .Property(e => e.maCongNo)
                .IsUnicode(false);

            modelBuilder.Entity<HanMucCongNo>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<HanMucCongNo>()
                .Property(e => e.soTienNop)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HanMucCongNo>()
                .Property(e => e.soLuongTanXuat)
                .HasPrecision(18, 3);

            modelBuilder.Entity<HanMucCongNo>()
                .Property(e => e.soLuongM3Xuat)
                .HasPrecision(18, 3);

            modelBuilder.Entity<HanMucCongNo>()
                .Property(e => e.thanhTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<HanMucCongNo>()
                .Property(e => e.tienConLai)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.maSoThue)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HanMucCongNoes)
                .WithRequired(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kho>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<Kho>()
                .Property(e => e.maKho)
                .IsUnicode(false);

            modelBuilder.Entity<MaTienTe>()
                .Property(e => e.maTienTe1)
                .IsUnicode(false);

            modelBuilder.Entity<MaTienTe>()
                .HasMany(e => e.Gias)
                .WithOptional(e => e.MaTienTe)
                .HasForeignKey(e => e.maNgoaiTe);

            modelBuilder.Entity<MayXay>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<MayXay>()
                .Property(e => e.maMayXay)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.tenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.quyen)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maSoThue)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<NhapXuat>()
                .Property(e => e.maNhapXuat)
                .IsUnicode(false);

            modelBuilder.Entity<NhapXuat>()
                .HasMany(e => e.PhieuThus)
                .WithOptional(e => e.NhapXuat)
                .HasForeignKey(e => e.lenhXuat);

            modelBuilder.Entity<NhomThanhPham>()
                .Property(e => e.maNhom)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.maDon)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.bienSoXe)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.trongLuongXeVao)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.trongLuongXeRa)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.lenhXuat)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.maSP)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.soLuongTan)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.soLuongM3)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.donGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.thanhTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.tienThanhToan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.maKho)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.maMayXay)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.maMayXuc)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuThu>()
                .Property(e => e.ghiChu)
                .IsUnicode(false);

            modelBuilder.Entity<SaLan>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<SaLan>()
                .Property(e => e.maSaLan)
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

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.PhieuThus)
                .WithOptional(e => e.SanPham)
                .HasForeignKey(e => e.maSP);

            modelBuilder.Entity<TramCan>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<TramCan>()
                .Property(e => e.maTramCan)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.bienSoXe)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<Xe>()
                .Property(e => e.trongLuongBanThan)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Xe>()
                .Property(e => e.trongLuongChoPhep)
                .HasPrecision(18, 3);

            modelBuilder.Entity<XeXuc>()
                .Property(e => e.maDonVi)
                .IsUnicode(false);

            modelBuilder.Entity<XeXuc>()
                .Property(e => e.maXeXuc)
                .IsUnicode(false);

            modelBuilder.Entity<XeXuc>()
                .HasMany(e => e.PhieuThus)
                .WithOptional(e => e.XeXuc)
                .HasForeignKey(e => e.maMayXuc);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.DK1)
                .IsUnicode(false);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.DK2)
                .IsUnicode(false);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.DK3)
                .IsUnicode(false);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SLTanDK1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SLTanDK2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SLTanDK3)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SLM3DK1)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SLM3DK2)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SLM3DK3)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SoTienDK1)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SoTienDK2)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.SoTienDK3)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.TongTan)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.TongM3)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ThongKe>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);
        }

        public string GetNextMaPhieu()
        {
            string nextMaPhieu = "1";

            //Truy vấn mã phiếu mới nhất từ cơ sở dữ liệu
            var latestPhieu = PhieuThus.OrderByDescending(p => p.maDon).FirstOrDefault(p => !p.maDon.StartsWith("H"));

            if (latestPhieu != null)
            {
                //Nếu đã có dữ liệu, tăng mã phiếu mới nhất lên 1 để tạo mã mới
                int currentMaPhieu = int.Parse(latestPhieu.maDon);
                nextMaPhieu = (currentMaPhieu + 1).ToString();
            }

            return nextMaPhieu;
        }

        public string GetOldestMaPhieu()
        {
            string prevMaPhieu = "0";

            //Truy vấn mã phiếu cũ nhất từ cơ sở dữ liệu
            var oldestPhieu = PhieuThus.OrderBy(p => p.maDon).FirstOrDefault();

            if (oldestPhieu != null)
            {
                prevMaPhieu = oldestPhieu.maDon.ToString();
            }

            return prevMaPhieu;
        }
    }
}
