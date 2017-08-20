using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DuyetVaySieuToc.Models.DataModel;
using System.Web.Script.Serialization;

namespace DuyetVaySieuToc.Models.BusinessModel
{

    public class QuanLyNguoiDung
    {
        Model1 db = null;
        public QuanLyNguoiDung()
        {
            db = new Model1();

        }
        public NGUOIDUNG Login(string taiKhoan, string matkhau)
        {
            var reslut = db.NGUOIDUNGs.Where(n => n.TAIKHOAN == taiKhoan && n.MATKHAU == matkhau).SingleOrDefault();
            if (reslut != null)
            {
                return reslut;
            }
            return null;
        }
        public IEnumerable<object> getAllMember()
        {
            var model = new List<object>();
            var category = from lsp in db.NGUOIDUNGs select lsp;
            foreach (var item in category)
            {
                model.Add(new
                {
                    MAND = item.MAND,
                    MALOAIND = item.MALOAIND,
                    TAIKHOAN = item.TAIKHOAN,
                    MATKHAU = item.MATKHAU,
                    SDT = item.SDT,
                    DIACHI = item.DIACHI,
                    EMAIL = item.EMAIL,
                    NgaySinh = string.Format("{0:dd/MM/yyyy}", item.NGAYSINH),
                    HOTEN = item.HOTEN,
                });

            }
            return model.ToList();
        }
        public object getMember(int id)
        {
            object res;
            var item = (from lsp in db.NGUOIDUNGs where lsp.MAND == id select lsp).SingleOrDefault();
            res = new
            {
                MAND = item.MAND,
                MALOAIND = item.MALOAIND,
                TAIKHOAN = item.TAIKHOAN,
                MATKHAU = item.MATKHAU,
                SDT = item.SDT,
                DIACHI = item.DIACHI,
                EMAIL = item.EMAIL,
                NgaySinh = string.Format("{0:dd/MM/yyyy}", item.NGAYSINH),
                HOTEN = item.HOTEN,
            };
            return res;
        }
        public int AddMember(string strCategory)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            NGUOIDUNG loaisanpham = serializer.Deserialize<NGUOIDUNG>(strCategory);
            db.NGUOIDUNGs.Add(loaisanpham);
            db.SaveChanges();
            return loaisanpham.MAND;
        }
        public int UpdateMember(string strUpdate)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            NGUOIDUNG item = serializer.Deserialize<NGUOIDUNG>(strUpdate);
            NGUOIDUNG LspUpdate = db.NGUOIDUNGs.Find(item.MAND);
            if (LspUpdate != null)
            {
                LspUpdate.MAND = item.MAND;
                LspUpdate.MALOAIND = item.MALOAIND;
                LspUpdate.TAIKHOAN = item.TAIKHOAN;
                LspUpdate.MATKHAU = item.MATKHAU;
                LspUpdate.SDT = item.SDT;
                LspUpdate.DIACHI = item.DIACHI;
                LspUpdate.EMAIL = item.EMAIL;
                LspUpdate.NGAYSINH = item.NGAYSINH;
                LspUpdate.HOTEN = item.HOTEN;

            }
            db.SaveChanges();
            return item.MAND;
        }
        public NGUOIDUNG DeleteMember(int? maloai)
        {
            var reslut = db.NGUOIDUNGs.Find(maloai);
            if (reslut != null)
            {
                db.NGUOIDUNGs.Remove(reslut);
                db.SaveChanges();
            }

            return reslut;
        }
    }
}