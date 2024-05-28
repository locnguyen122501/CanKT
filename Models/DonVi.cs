namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonVi")]
    public partial class DonVi
    {
        [Key]
        [StringLength(50)]
        public string maDonVi { get; set; }

        [StringLength(100)]
        public string tenDonVi { get; set; }

        [StringLength(255)]
        public string tenKhac { get; set; }

        [StringLength(255)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }
    }
}
