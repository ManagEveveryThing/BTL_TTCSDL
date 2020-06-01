namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DScanhcao")]
    public partial class DScanhcao
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maCanhCao { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maSV { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual CanhCao CanhCao { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
