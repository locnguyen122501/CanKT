namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhomThanhPham")]
    public partial class NhomThanhPham
    {
        [Key]
        [Column("nhomThanhPham", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nhomThanhPham1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string maNhom { get; set; }

        [StringLength(50)]
        public string tenNhom { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        public int? trangThai { get; set; }
    }
}
