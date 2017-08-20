namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINHTRANG")]
    public partial class TINHTRANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TINHTRANG()
        {
            NGUOIDUNGVAYs = new HashSet<NGUOIDUNGVAY>();
        }

        [Key]
        public int MATINHTRANG { get; set; }

        public int? TRANGTHAI { get; set; }

        public DateTime? NGAYTAO { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        public int? LyDo { get; set; }

        public DateTime? NGAYDUYET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGUOIDUNGVAY> NGUOIDUNGVAYs { get; set; }
    }
}
