namespace DuyetVaySieuToc.Models.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAPQUYEN")]
    public partial class CAPQUYEN
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAND { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MAQUYEN { get; set; }

        [StringLength(256)]
        public string MOTA { get; set; }

        public virtual NGUOIDUNG NGUOIDUNG { get; set; }

        public virtual QUYEN QUYEN { get; set; }
    }
}
