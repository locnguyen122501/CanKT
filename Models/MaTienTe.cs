namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaTienTe")]
    public partial class MaTienTe
    {
        [Key]
        [Column("maTienTe")]
        [StringLength(50)]
        public string maTienTe1 { get; set; }

        [StringLength(50)]
        public string tenTienTe { get; set; }

        public int? trangThai { get; set; }
    }
}
