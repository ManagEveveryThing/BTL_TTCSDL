namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSSVLopHP")]
    public partial class DSSVLopHP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string malopHP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maSV { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public double? diem1 { get; set; }

        public double? diem3 { get; set; }

        public double? diem6 { get; set; }

        public double? diemHe4 { get; set; }

        public virtual LopHP LopHP { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
