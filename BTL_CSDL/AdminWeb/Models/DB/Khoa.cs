namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khoa")]
    public partial class Khoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khoa()
        {
            BoMons = new HashSet<BoMon>();
        }

        [StringLength(8)]
        public string maTruongKhoa { get; set; }

        [Key]
        [StringLength(8)]
        public string maKhoa { get; set; }

        [StringLength(100)]
        public string tenKhoa { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoMon> BoMons { get; set; }

        public virtual GiangVien GiangVien { get; set; }
    }
}
