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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kho()
        {
            Gias = new HashSet<Gia>();
            PhieuThus = new HashSet<PhieuThu>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gia> Gias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}
