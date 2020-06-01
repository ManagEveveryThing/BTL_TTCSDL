namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopCNSv")]
    public partial class LopCNSv
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopCNSv()
        {
            DSCoVanHTs = new HashSet<DSCoVanHT>();
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        [StringLength(8)]
        public string maLopCN { get; set; }

        [StringLength(100)]
        public string tenLopCN { get; set; }

        [StringLength(8)]
        public string maCNDT { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public int? soLuongSV { get; set; }

        public virtual ChuyenNganhDT ChuyenNganhDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSCoVanHT> DSCoVanHTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
