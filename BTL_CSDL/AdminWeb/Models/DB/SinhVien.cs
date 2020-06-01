namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SinhVien()
        {
            DScanhcaos = new HashSet<DScanhcao>();
            DSHocBongs = new HashSet<DSHocBong>();
            DSKQHTs = new HashSet<DSKQHT>();
            DSSVLopHPs = new HashSet<DSSVLopHP>();
            DSSVThiKetThucs = new HashSet<DSSVThiKetThuc>();
            DSDiemDanhSVs = new HashSet<DSDiemDanhSV>();
            TrinhDoNNs = new HashSet<TrinhDoNN>();
        }

        [Key]
        [StringLength(8)]
        public string maSV { get; set; }

        [StringLength(8)]
        public string maLopCN { get; set; }

        [StringLength(100)]
        public string tenSV { get; set; }

        [StringLength(100)]
        public string hoSV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaySinh { get; set; }

        [StringLength(4)]
        public string gioiTinh { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        [StringLength(10)]
        public string sdtPhuHUynh { get; set; }

        [StringLength(100)]
        public string maKhoaSv { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public bool? isLearn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DScanhcao> DScanhcaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSHocBong> DSHocBongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSKQHT> DSKQHTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSSVLopHP> DSSVLopHPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSSVThiKetThuc> DSSVThiKetThucs { get; set; }

        public virtual KhoaSv KhoaSv { get; set; }

        public virtual LopCNSv LopCNSv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSDiemDanhSV> DSDiemDanhSVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrinhDoNN> TrinhDoNNs { get; set; }
    }
}
