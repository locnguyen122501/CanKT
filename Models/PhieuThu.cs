namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuThu")]
    public partial class PhieuThu
    {
        [Key]
        [StringLength(50)]
        public string maDon { get; set; }

        [StringLength(50)]
        public string bienSoXe { get; set; }

        [StringLength(50)]
        public string maKH { get; set; }

        public int? trongLuongXeVao { get; set; }

        public int? trongLuongXeRa { get; set; }

        [StringLength(50)]
        public string lenhXuat { get; set; }

        [StringLength(50)]
        public string maSP { get; set; }

        public int? soLuongTan { get; set; }

        public int? soLuongM3 { get; set; }

        [Column(TypeName = "money")]
        public decimal? donGia { get; set; }

        [Column(TypeName = "money")]
        public decimal? thanhTien { get; set; }

        [Column(TypeName = "money")]
        public decimal? tienThanhToan { get; set; }

        [StringLength(50)]
        public string maKho { get; set; }

        [StringLength(50)]
        public string maMayXay { get; set; }

        [StringLength(50)]
        public string maMayXuc { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Kho Kho { get; set; }

        public virtual MayXay MayXay { get; set; }

        public virtual NhapXuat NhapXuat { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual Xe Xe { get; set; }

        public virtual XeXuc XeXuc { get; set; }
    }
}
