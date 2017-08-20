namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NGUOIDUNGVAY")]
    public partial class NGUOIDUNGVAY
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [StringLength(500)]
        public string DIACHI { get; set; }

        [StringLength(500)]
        public string VAYTHEO { get; set; }

        public int? TRANGTHAI { get; set; }

        [StringLength(100)]
        public string TINH { get; set; }

        public string GHICHU { get; set; }

        public int? TINHTRANG { get; set; }

        [StringLength(100)]
        public string TEAM { get; set; }

        public DateTime? NGAYDANGKY { get; set; }

        public DateTime? NGAYDUYET { get; set; }

        public int MATINHTRANG { get; set; }

        public int MATHONGBAO { get; set; }

        [StringLength(100)]
        public string HOTEN { get; set; }

        public virtual THONGBAO THONGBAO { get; set; }

        public virtual TINHTRANG TINHTRANG1 { get; set; }
    }
}
