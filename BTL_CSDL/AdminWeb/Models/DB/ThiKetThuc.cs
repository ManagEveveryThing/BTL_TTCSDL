namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThiKetThuc")]
    public partial class ThiKetThuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThiKetThuc()
        {
            DSGiamThis = new HashSet<DSGiamThi>();
            DSHPThiKetThucs = new HashSet<DSHPThiKetThuc>();
            DSSVThiKetThucs = new HashSet<DSSVThiKetThuc>();
        }

        [Key]
        [StringLength(8)]
        public string maThiKetThuc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngayThi { get; set; }

        public TimeSpan? thoiGianBatDau { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGiamThi> DSGiamThis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSHPThiKetThuc> DSHPThiKetThucs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSSVThiKetThuc> DSSVThiKetThucs { get; set; }
    }
}
