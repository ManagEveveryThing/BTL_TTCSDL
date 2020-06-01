namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSKQHT")]
    public partial class DSKQHT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string maSV { get; set; }

        [StringLength(15)]
        public string tenXepLoai { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string tenKy { get; set; }

        public double? diem { get; set; }

        public int? sotinchino { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual KyHoc KyHoc { get; set; }

        public virtual SinhVien SinhVien { get; set; }

        public virtual XepLoai XepLoai { get; set; }
    }
}
