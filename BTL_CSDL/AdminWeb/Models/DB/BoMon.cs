namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BoMon")]
    public partial class BoMon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BoMon()
        {
            ChuyenNganhDTs = new HashSet<ChuyenNganhDT>();
            GiangViens = new HashSet<GiangVien>();
        }

        [StringLength(8)]
        public string maTruongBM { get; set; }

        [Key]
        [StringLength(8)]
        public string maBM { get; set; }

        [StringLength(8)]
        public string maKhoa { get; set; }

        [StringLength(100)]
        public string tenBM { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public int? soLuongGV { get; set; }

        public virtual GiangVien GiangVien { get; set; }

        public virtual Khoa Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuyenNganhDT> ChuyenNganhDTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GiangVien> GiangViens { get; set; }
    }
}
