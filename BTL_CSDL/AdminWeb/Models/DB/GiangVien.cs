namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiangVien")]
    public partial class GiangVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiangVien()
        {
            BoMons = new HashSet<BoMon>();
            DSCoVanHTs = new HashSet<DSCoVanHT>();
            DSGiamThis = new HashSet<DSGiamThi>();
            DSGVChamBais = new HashSet<DSGVChamBai>();
            DSGVHPs = new HashSet<DSGVHP>();
            HocViGVs = new HashSet<HocViGV>();
            Khoas = new HashSet<Khoa>();
        }

        [Key]
        [StringLength(8)]
        public string maGV { get; set; }

        [StringLength(8)]
        public string maBM { get; set; }

        [StringLength(100)]
        public string tenGV { get; set; }

        [StringLength(100)]
        public string hoGV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        [StringLength(4)]
        public string gioiTinh { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoMon> BoMons { get; set; }

        public virtual BoMon BoMon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSCoVanHT> DSCoVanHTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGiamThi> DSGiamThis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGVChamBai> DSGVChamBais { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGVHP> DSGVHPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HocViGV> HocViGVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Khoa> Khoas { get; set; }
    }
}
