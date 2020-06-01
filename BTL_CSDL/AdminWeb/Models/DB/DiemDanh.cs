namespace AdminWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DiemDanh")]
    public partial class DiemDanh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiemDanh()
        {
            DSDiemDanhSVs = new HashSet<DSDiemDanhSV>();
        }

        [Key]
        [StringLength(8)]
        public string maDD { get; set; }

        [Required]
        [StringLength(8)]
        public string maLopHP { get; set; }

        public int? soBuoiDiemDanh { get; set; }

        public virtual LopHP LopHP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSDiemDanhSV> DSDiemDanhSVs { get; set; }
    }
}
