namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HanMucCongNo")]
    public partial class HanMucCongNo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string maCongNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string maKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay { get; set; }

        [Column(TypeName = "money")]
        public decimal? soTienNop { get; set; }

        public decimal? soLuongTanXuat { get; set; }

        public decimal? soLuongM3Xuat { get; set; }

        [Column(TypeName = "money")]
        public decimal? thanhTien { get; set; }

        [Column(TypeName = "money")]
        public decimal? tienConLai { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
