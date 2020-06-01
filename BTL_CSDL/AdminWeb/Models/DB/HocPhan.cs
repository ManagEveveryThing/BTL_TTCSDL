namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocPhan")]
    public partial class HocPhan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HocPhan()
        {
            CHiTietHPs = new HashSet<CHiTietHP>();
            DSGVHPs = new HashSet<DSGVHP>();
            LichHPs = new HashSet<LichHP>();
            LopHPs = new HashSet<LopHP>();
        }

        [Key]
        [StringLength(8)]
        public string maHP { get; set; }

        public int? soTC { get; set; }

        [StringLength(8)]
        public string maPKT { get; set; }

        [StringLength(100)]
        public string tenHP { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHiTietHP> CHiTietHPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGVHP> DSGVHPs { get; set; }

        public virtual PhanKT PhanKT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichHP> LichHPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LopHP> LopHPs { get; set; }
    }
}
