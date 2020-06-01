namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSDeThi")]
    public partial class DSDeThi
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maBaiThi { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string maDeThi { get; set; }

        public int? soTo { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual BaiThi BaiThi { get; set; }
    }
}
