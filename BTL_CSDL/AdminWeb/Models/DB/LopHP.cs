namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHP")]
    public partial class LopHP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LopHP()
        {
            DiemDanhs = new HashSet<DiemDanh>();
            DSGiangDuongs = new HashSet<DSGiangDuong>();
            DSHPThiKetThucs = new HashSet<DSHPThiKetThuc>();
            DSSVLopHPs = new HashSet<DSSVLopHP>();
        }

        [StringLength(8)]
        public string maHP { get; set; }

        [Key]
        [StringLength(8)]
        public string maLopHP { get; set; }

        public int? maxStore { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public int? curStore { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGiangDuong> DSGiangDuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSHPThiKetThuc> DSHPThiKetThucs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSSVLopHP> DSSVLopHPs { get; set; }

        public virtual HocPhan HocPhan { get; set; }
    }
}
