namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoaSv")]
    public partial class KhoaSv
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoaSv()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        [Key]
        [StringLength(100)]
        public string maKhoaSv { get; set; }

        [StringLength(100)]
        public string tenKhoaSv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? namThanhLap { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        public int? soLuongSV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
