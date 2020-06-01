namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XepLoai")]
    public partial class XepLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XepLoai()
        {
            DSKQHTs = new HashSet<DSKQHT>();
        }

        [Key]
        [StringLength(15)]
        public string tenXepLoai { get; set; }

        public double? diem { get; set; }

        [StringLength(200)]
        public string chuThich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSKQHT> DSKQHTs { get; set; }
    }
}
