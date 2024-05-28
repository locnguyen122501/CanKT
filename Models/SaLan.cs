namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaLan")]
    public partial class SaLan
    {
        [StringLength(50)]
        public string maDonVi { get; set; }

        [Key]
        [StringLength(50)]
        public string maSaLan { get; set; }

        [StringLength(50)]
        public string tenSaLan { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        [StringLength(255)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }
    }
}
