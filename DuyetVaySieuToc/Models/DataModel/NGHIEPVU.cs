namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGHIEPVU")]
    public partial class NGHIEPVU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGHIEPVU()
        {
            QUYENs = new HashSet<QUYEN>();
        }

        [Key]
        [StringLength(64)]
        public string MANGIEPVU { get; set; }

        [StringLength(256)]
        public string TENNGHIEPVU { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QUYEN> QUYENs { get; set; }
    }
}
