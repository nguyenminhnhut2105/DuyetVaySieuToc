using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuyetVaySieuToc.Models.ViewModel
{
    public class KhachHangVayViewModel
    {
        public int ID { get; set; }
        public string SDT { get; set; }
        public string CMND { get; set; }
        public string DIACHI { get; set; }
        public string VAYTHEO { get; set; }
        public int? TRANGTHAI { get; set; }
        public string TINH { get; set; }
        public string GHICHU { get; set; }
        public int? TINHTRANG { get; set; }
        public string TEAM { get; set; }
        public DateTime? NGAYDANGKY { get; set; }
        public DateTime? NGAYDUYET { get; set; }
        public int MATINHTRANG { get; set; }
        public int MATHONGBAO { get; set; }
        public string HOTEN { get; set; }
    }
}