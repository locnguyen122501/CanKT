namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Xe")]
    public partial class Xe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Xe()
        {
            PhieuThus = new HashSet<PhieuThu>();
        }

        [Key]
        [StringLength(50)]
        public string bienSoXe { get; set; }

        [StringLength(50)]
        public string tenXe { get; set; }

        [StringLength(50)]
        public string tenKhac { get; set; }

        public int? loaiXe { get; set; }

        [StringLength(50)]
        public string maKH { get; set; }

        [StringLength(50)]
        public string tenTaiXe { get; set; }

        public decimal? trongLuongBanThan { get; set; }

        public decimal? trongLuongChoPhep { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayKetDangKiem { get; set; }

        public int? trangThai { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuThu> PhieuThus { get; set; }
    }
}
