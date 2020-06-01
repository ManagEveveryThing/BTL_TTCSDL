namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NganhDT")]
    public partial class NganhDT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NganhDT()
        {
            ChuyenNganhDTs = new HashSet<ChuyenNganhDT>();
        }

        [Key]
        [StringLength(8)]
        public string maNganhDT { get; set; }

        [StringLength(100)]
        public string tenNganhDT { get; set; }

        [StringLength(8)]
        public string maBoMon { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuyenNganhDT> ChuyenNganhDTs { get; set; }
    }
}
