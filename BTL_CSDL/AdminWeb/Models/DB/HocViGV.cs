namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocViGV")]
    public partial class HocViGV
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maGV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string tenHV { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual GiangVien GiangVien { get; set; }
    }
}
