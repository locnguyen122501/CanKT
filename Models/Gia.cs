namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gia")]
    public partial class Gia
    {
        [StringLength(50)]
        public string maBoPhan { get; set; }

        [Key]
        [StringLength(50)]
        public string maDonGia { get; set; }

        [StringLength(50)]
        public string maThanhPham { get; set; }

        [StringLength(50)]
        public string maKho { get; set; }

        [StringLength(50)]
        public string maNgoaiTe { get; set; }

        [Column(TypeName = "money")]
        public decimal? donGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayHieuLuc { get; set; }

        [StringLength(255)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }

        public virtual BoPhan BoPhan { get; set; }

        public virtual Kho Kho { get; set; }

        public virtual MaTienTe MaTienTe { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
