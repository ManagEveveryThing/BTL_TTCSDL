namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSGVHP")]
    public partial class DSGVHP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maGV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maHP { get; set; }

        [StringLength(1)]
        public string chuThich { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual HocPhan HocPhan { get; set; }
    }
}
