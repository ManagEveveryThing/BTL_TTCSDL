namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanhCao")]
    public partial class CanhCao
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CanhCao()
        {
            DScanhcaos = new HashSet<DScanhcao>();
        }

        [Key]
        [StringLength(8)]
        public string maCanhCao { get; set; }

        [StringLength(100)]
        public string tenCanhCao { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DScanhcao> DScanhcaos { get; set; }
    }
}
