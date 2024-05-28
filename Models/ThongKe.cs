namespace CanKT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongKe")]
    public partial class ThongKe
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int STT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string DK1 { get; set; }

        [StringLength(50)]
        public string DK2 { get; set; }

        [StringLength(50)]
        public string DK3 { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal SLTanDK1 { get; set; }

        public decimal? SLTanDK2 { get; set; }

        public decimal? SLTanDK3 { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal SLM3DK1 { get; set; }

        public decimal? SLM3DK2 { get; set; }

        public decimal? SLM3DK3 { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "money")]
        public decimal SoTienDK1 { get; set; }

        [Column(TypeName = "money")]
        public decimal? SoTienDK2 { get; set; }

        [Column(TypeName = "money")]
        public decimal? SoTienDK3 { get; set; }

        [Key]
        [Column(Order = 5)]
        public decimal TongTan { get; set; }

        [Key]
        [Column(Order = 6)]
        public decimal TongM3 { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "money")]
        public decimal TongTien { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SoTrang { get; set; }
    }
}
