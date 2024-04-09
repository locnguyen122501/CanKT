namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kho")]
    public partial class Kho
    {
        [StringLength(50)]
        public string maDonVi { get; set; }

        [Key]
        [StringLength(50)]
        public string maKho { get; set; }

        [StringLength(50)]
        public string tenKho { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        [StringLength(50)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }

        public virtual DonVi DonVi { get; set; }
    }
}
