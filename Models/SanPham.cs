namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            Gias = new HashSet<Gia>();
            PhieuThus = new HashSet<PhieuThu>();
        }

        [Key]
        [StringLength(50)]
        public string maThanhPham { get; set; }

        [StringLength(50)]
        public string tenThanhPham { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        [StringLength(50)]
        public string maDonViTinh { get; set; }

        public double? heSoQuyDoi { get; set; }

        [StringLength(50)]
        public string maKho { get; set; }

        public int? loaiHang { get; set; }

        public int? nhom { get; set; }

        [StringLength(50)]
        public string maThue { get; set; }

        [StringLength(255)]
        public string ghiChu { get; set; }

        public int? trangThai { get; set; }

        public virtual DonViTinh DonViTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gia> Gias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}
