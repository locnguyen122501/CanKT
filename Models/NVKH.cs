namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NVKH")]
    public partial class NVKH
    {
        [Key]
        [StringLength(50)]
        public string maNVKH { get; set; }

        [StringLength(50)]
        public string tenNVKH { get; set; }

        public int? loai { get; set; }

        [StringLength(50)]
        public string tenDangNhap { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        [StringLength(50)]
        public string maSoThue { get; set; }

        [StringLength(50)]
        public string diaChi { get; set; }

        public int? sdt { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
