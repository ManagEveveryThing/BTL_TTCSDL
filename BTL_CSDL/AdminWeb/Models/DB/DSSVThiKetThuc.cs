namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSSVThiKetThuc")]
    public partial class DSSVThiKetThuc
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maSV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maBaiThi { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(8)]
        public string maThiKetThuc { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual BaiThi BaiThi { get; set; }

        public virtual SinhVien SinhVien { get; set; }

        public virtual ThiKetThuc ThiKetThuc { get; set; }
    }
}
