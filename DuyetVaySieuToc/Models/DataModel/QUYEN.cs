namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYEN")]
    public partial class QUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QUYEN()
        {
            CAPQUYENs = new HashSet<CAPQUYEN>();
        }

        [Key]
        public int MAQUYEN { get; set; }

        [Required]
        [StringLength(64)]
        public string MANGIEPVU { get; set; }

        [StringLength(100)]
        public string TENQUYEN { get; set; }

        [StringLength(256)]
        public string MOTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAPQUYEN> CAPQUYENs { get; set; }

        public virtual NGHIEPVU NGHIEPVU { get; set; }
    }
}
