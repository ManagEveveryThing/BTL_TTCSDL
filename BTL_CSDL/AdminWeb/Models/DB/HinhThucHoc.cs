namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhThucHoc")]
    public partial class HinhThucHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HinhThucHoc()
        {
            CHiTietHPs = new HashSet<CHiTietHP>();
        }

        [Key]
        [StringLength(100)]
        public string tenHinhThuc { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHiTietHP> CHiTietHPs { get; set; }
    }
}
