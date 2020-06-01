namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSGiamThi")]
    public partial class DSGiamThi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maThiKetThuc { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayPC { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual ThiKetThuc ThiKetThuc { get; set; }
    }
}
