namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string maNV { get; set; }

        [StringLength(50)]
        public string tenNV { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string tenTaiKhoan { get; set; }

        [StringLength(50)]
        public string matKhau { get; set; }

        [StringLength(50)]
        public string quyen { get; set; }

        [StringLength(50)]
        public string maSoThue { get; set; }

        [StringLength(255)]
        public string diaChi { get; set; }

        [StringLength(50)]
        public string sdt { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(255)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }
    }
}
