namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichHP")]
    public partial class LichHP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maHP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string tietHoc { get; set; }

        public int? soLuong { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string thu { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual HocPhan HocPhan { get; set; }

        public virtual TietHoc TietHoc1 { get; set; }
    }
}
