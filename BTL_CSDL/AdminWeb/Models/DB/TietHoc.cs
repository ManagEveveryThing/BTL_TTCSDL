namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TietHoc")]
    public partial class TietHoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TietHoc()
        {
            LichHPs = new HashSet<LichHP>();
        }

        [Key]
        [Column("tietHoc")]
        [StringLength(2)]
        public string tietHoc1 { get; set; }

        public TimeSpan? timeStart { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichHP> LichHPs { get; set; }
    }
}
