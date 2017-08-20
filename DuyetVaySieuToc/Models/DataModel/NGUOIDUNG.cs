namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNG")]
    public partial class NGUOIDUNG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NGUOIDUNG()
        {
            CAPQUYENs = new HashSet<CAPQUYEN>();
        }

        [Key]
        public int MAND { get; set; }

        public int MALOAIND { get; set; }

        [StringLength(100)]
        public string TAIKHOAN { get; set; }

        [StringLength(100)]
        public string MATKHAU { get; set; }

        [StringLength(12)]
        public string SDT { get; set; }

        [StringLength(255)]
        public string DIACHI { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        public DateTime? NGAYTAO { get; set; }

        public int? QUANTRI { get; set; }

        public int? KICHHOAT { get; set; }

        [StringLength(255)]
        public string HOTEN { get; set; }

        public DateTime? NGAYSINH { get; set; }

        public bool? GioiTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAPQUYEN> CAPQUYENs { get; set; }

        public virtual LOAINGUOIDUNG LOAINGUOIDUNG { get; set; }
    }
}
