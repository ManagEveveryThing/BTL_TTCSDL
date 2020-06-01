namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSDiemDanhSV")]
    public partial class DSDiemDanhSV
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maDD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string maSV { get; set; }

        public int? soBuoi { get; set; }

        public virtual DiemDanh DiemDanh { get; set; }

        public virtual SinhVien SinhVien { get; set; }
    }
}
