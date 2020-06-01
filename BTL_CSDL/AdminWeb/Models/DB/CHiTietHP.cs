namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHiTietHP")]
    public partial class CHiTietHP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maHP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string TenHinhThuc { get; set; }

        public int? sotiet { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual HinhThucHoc HinhThucHoc { get; set; }

        public virtual HocPhan HocPhan { get; set; }
    }
}
