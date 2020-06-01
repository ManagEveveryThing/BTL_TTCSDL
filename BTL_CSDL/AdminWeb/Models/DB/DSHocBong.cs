namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSHocBong")]
    public partial class DSHocBong
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maHocBong { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string MaSV { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual HocBong HocBong { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
