namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("findStudent")]
    public partial class findStudent
    {
        [Key]
        [StringLength(8)]
        public string maSV { get; set; }

        [StringLength(100)]
        public string tenSV { get; set; }

        [StringLength(100)]
        public string hoSV { get; set; }

        public DateTime? ngaySinh { get; set; }

        [StringLength(100)]
        public string TenLopCN { get; set; }

        [StringLength(100)]
        public string TenKhoaSV { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }
    }
}
