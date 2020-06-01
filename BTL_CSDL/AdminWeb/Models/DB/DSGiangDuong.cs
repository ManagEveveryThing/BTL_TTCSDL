namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSGiangDuong")]
    public partial class DSGiangDuong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maGD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maLopHP { get; set; }

        public int? thu { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual GiangDuong GiangDuong { get; set; }

        public virtual LopHP LopHP { get; set; }
    }
}
