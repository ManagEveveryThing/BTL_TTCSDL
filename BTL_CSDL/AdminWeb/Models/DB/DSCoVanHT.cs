namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSCoVanHT")]
    public partial class DSCoVanHT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maLopCN { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maCV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayThanhLap { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual LopCNSv LopCNSv { get; set; }
    }
}
