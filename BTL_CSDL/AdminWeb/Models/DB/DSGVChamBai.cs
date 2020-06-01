namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSGVChamBai")]
    public partial class DSGVChamBai
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maBaiThi { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayCham { get; set; }

        public double? diem { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual BaiThi BaiThi { get; set; }

        public virtual GiangVien GiangVien { get; set; }
    }
}
