namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TramCan")]
    public partial class TramCan
    {
        [StringLength(50)]
        public string maBoPhan { get; set; }

        [Key]
        [StringLength(50)]
        public string maTramCan { get; set; }

        [StringLength(50)]
        public string tenTramCan { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        [StringLength(255)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }

        public virtual BoPhan BoPhan { get; set; }
    }
}
