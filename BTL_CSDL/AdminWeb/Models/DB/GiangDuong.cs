namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiangDuong")]
    public partial class GiangDuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiangDuong()
        {
            DSGiangDuongs = new HashSet<DSGiangDuong>();
        }

        [Key]
        [StringLength(8)]
        public string maGD { get; set; }

        public int? soPhong { get; set; }

        public int? tang { get; set; }

        [StringLength(100)]
        public string viTri { get; set; }

        public int? sucChua { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSGiangDuong> DSGiangDuongs { get; set; }
    }
}
