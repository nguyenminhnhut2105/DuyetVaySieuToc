namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THONGBAO")]
    public partial class THONGBAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THONGBAO()
        {
            NGUOIDUNGVAYs = new HashSet<NGUOIDUNGVAY>();
        }

        [Key]
        public int MATHONGBAO { get; set; }

        [StringLength(500)]
        public string NOIDUNG { get; set; }

        public DateTime? NGAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NGUOIDUNGVAY> NGUOIDUNGVAYs { get; set; }
    }
}
