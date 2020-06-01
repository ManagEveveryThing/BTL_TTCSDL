namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSHPThiKetThuc")]
    public partial class DSHPThiKetThuc
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maLopHP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maThiKetThuc { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual LopHP LopHP { get; set; }

        public virtual ThiKetThuc ThiKetThuc { get; set; }
    }
}
