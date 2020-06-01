namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiThi")]
    public partial class BaiThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiThi()
        {
            DSDeThis = new HashSet<DSDeThi>();
            DSGVChamBais = new HashSet<DSGVChamBai>();
            DSSVThiKetThucs = new HashSet<DSSVThiKetThuc>();
        }

        [Key]
        [StringLength(8)]
        public string maBaiThi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayTao { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSDeThi> DSDeThis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGVChamBai> DSGVChamBais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSSVThiKetThuc> DSSVThiKetThucs { get; set; }
    }
}
