namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuyenNganhDT")]
    public partial class ChuyenNganhDT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuyenNganhDT()
        {
            LopCNSvs = new HashSet<LopCNSv>();
        }

        [StringLength(8)]
        public string maNganhDT { get; set; }

        [Key]
        [StringLength(8)]
        public string maChuyenNganh { get; set; }

        [StringLength(8)]
        public string maBoMon { get; set; }

        [StringLength(100)]
        public string tenChuyenNganh { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public virtual BoMon BoMon { get; set; }

        public virtual NganhDT NganhDT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopCNSv> LopCNSvs { get; set; }
    }
}
