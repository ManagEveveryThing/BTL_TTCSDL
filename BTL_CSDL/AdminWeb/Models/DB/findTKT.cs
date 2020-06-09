namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("findTKT")]
    public partial class findTKT
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
        public string tenHP { get; set; }

        public double? diemCC { get; set; }

        public double? diemTX { get; set; }

        public double? diemTHi { get; set; }
    }
}
