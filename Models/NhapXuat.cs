namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapXuat")]
    public partial class NhapXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhapXuat()
        {
            PhieuThus = new HashSet<PhieuThu>();
        }

        [Key]
        [StringLength(50)]
        public string maNhapXuat { get; set; }

        [StringLength(50)]
        public string tenNhapXuat { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        [StringLength(50)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}
