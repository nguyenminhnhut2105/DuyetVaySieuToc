using DuyetVaySieuToc.Models.BusinessModel;
using DuyetVaySieuToc.Models.DataModel;
using DuyetVaySieuToc.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DuyetVaySieuToc.Areas.Admin.Controllers
{
    [AuthorizeBusiness]
    [RouteArea("Quan-Ly-Nguoi-Dung")]
    public class QuanLyNguoiDungController : Controller
    {
        QuanLyNguoiDung nguoiDung = null;
        Model1 db = null;
        public QuanLyNguoiDungController()
        {
            nguoiDung = new QuanLyNguoiDung();
            db = new Model1();
        }
      
        // GET: QuanLy/QuanLyNguoiDung
        [Route("Loai-Nguoi-Dung")]
        public ActionResult Index()
        {
            var reslut = db.LOAINGUOIDUNGs.ToList().OrderBy(n => n.NGAYTAO);
            if (reslut != null)
            {
                return View(reslut);
            }
            return View();

        }
        public ActionResult Login()
        {
            return PartialView();
        }
        public ActionResult Create_EditCategoryUser(LOAINGUOIDUNG sp)
        {

            if (sp.MALOAIND == 0)
            {
                db.LOAINGUOIDUNGs.Add(sp);
                db.SaveChanges();
            }
            else
            {
                LOAINGUOIDUNG loaisp_ = db.LOAINGUOIDUNGs.Find(sp.MALOAIND);
                loaisp_.TENLOAIND = sp.TENLOAIND;
                sp.NGAYTAO = DateTime.Now;
                db.Entry(loaisp_).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteCategoryUser(int? idloainguoidung)
        {
            LOAINGUOIDUNG ls = db.LOAINGUOIDUNGs.Find(idloainguoidung);
            try
            {


                if (ls != null)
                {
                    db.LOAINGUOIDUNGs.Remove(ls);
                    db.SaveChanges();
                }

            }
            catch (Exception)
            {

                TempData["Mgs"] = "Đã có người dùng không thể xóa";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Member()
        {
            var reslut = db.NGUOIDUNGs;


            if (reslut != null)
            {
                return View(reslut);
            }
            return View();

        }
        public ActionResult DeleteMember(int? idloainguoidung)
        {
            NGUOIDUNG ls = db.NGUOIDUNGs.Find(idloainguoidung);
            try
            {

                if (ls != null)
                {
                    db.NGUOIDUNGs.Remove(ls);
                    db.SaveChanges();
                    TempData["Message"] = "Xóa Thành Công";
                }
            }
            catch (Exception)
            {

                TempData["Message"] = "Tài khoản này không thể xóa";
            }

            return RedirectToAction("Member");
        }
        private void Common()
        {

            List<SelectListItem> QUANTRI = new List<SelectListItem>()
                {
                    new SelectListItem() {Value ="1",Text = "Quản trị"},
                     new SelectListItem() {Value ="0",Text = "Không là quản trị"}

                };
            ViewBag.QUANTRI = QUANTRI;
            List<SelectListItem> KICHHOAT = new List<SelectListItem>()
                {
                    new SelectListItem() {Value ="1",Text = "Kích hoạt"},
                     new SelectListItem() {Value ="0",Text = "Chưa kích hoạt"}

                };
            ViewBag.KICHHOAT = KICHHOAT;
        }
        public ActionResult Create()
        {
            Common();
            ViewBag.MALOAIND = new SelectList(db.LOAINGUOIDUNGs, "MALOAIND", "TENLOAIND");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAND,MALOAIND,TAIKHOAN,MATKHAU,SDT,DIACHI,EMAIL,NGAYTAO,HOTEN,NGAYSINH,QUANTRI,KICHHOAT")] NGUOIDUNG nGUOIDUNG)
        {
            NGUOIDUNG nd = new NGUOIDUNG();
            if (ModelState.IsValid)
            {
                nd.HOTEN = nGUOIDUNG.HOTEN;
                nd.EMAIL = nGUOIDUNG.EMAIL;
                nd.DIACHI = nGUOIDUNG.DIACHI;
                string passMD5 = CommonMD5.EncryptMD5(nGUOIDUNG.TAIKHOAN + nGUOIDUNG.MATKHAU);
                nd.MATKHAU = passMD5;
                nd.MALOAIND = nGUOIDUNG.MALOAIND;
                nd.SDT = nGUOIDUNG.SDT;
                nd.TAIKHOAN = nGUOIDUNG.TAIKHOAN;
                nd.NGAYSINH = nGUOIDUNG.NGAYSINH;
                nd.GioiTinh = nGUOIDUNG.GioiTinh;
                nd.MALOAIND = nGUOIDUNG.MALOAIND;
                nd.QUANTRI = nGUOIDUNG.QUANTRI;
                nd.KICHHOAT = nGUOIDUNG.KICHHOAT;
                nd.NGAYTAO = DateTime.Now;
                db.NGUOIDUNGs.Add(nd);
                db.SaveChanges();
                return RedirectToAction("Member");
            }

            Common();
            ViewBag.MALOAIND = new SelectList(db.LOAINGUOIDUNGs, "MALOAIND", "TENLOAIND", nGUOIDUNG.MALOAIND);
            return View(nGUOIDUNG);
        }

        // GET: Admin/NGUOIDUNGs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNG nGUOIDUNG = db.NGUOIDUNGs.Find(id);
            if (nGUOIDUNG == null)
            {
                return HttpNotFound();
            }

            Common();
            ViewBag.MALOAIND = new SelectList(db.LOAINGUOIDUNGs, "MALOAIND", "TENLOAIND", nGUOIDUNG.MALOAIND);
            return View(nGUOIDUNG);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAND,MALOAIND,TAIKHOAN,MATKHAU,SDT,DIACHI,EMAIL,NGAYTAO,HOTEN,NGAYSINH,QUANTRI,KICHHOAT")] NGUOIDUNG nGUOIDUNG)
        {
            NGUOIDUNG nd = new NGUOIDUNG();
            if (ModelState.IsValid)
            {
                if (nd.MATKHAU == nGUOIDUNG.MATKHAU)
                {
                    nGUOIDUNG.MATKHAU = nd.MATKHAU;
                }
                else
                {
                    string passMD5 = CommonMD5.EncryptMD5(nGUOIDUNG.TAIKHOAN + nGUOIDUNG.MATKHAU);
                    nGUOIDUNG.MATKHAU = passMD5;
                }              
                db.Entry(nGUOIDUNG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Member");
            }
            Common();
            ViewBag.MALOAIND = new SelectList(db.LOAINGUOIDUNGs, "MALOAIND", "TENLOAIND", nGUOIDUNG.MALOAIND);
            return View(nGUOIDUNG);
        }

        //public FileResult ExportTo(string ReportType)
        //{
        //    LocalReport localReport = new LocalReport();
        //    localReport.ReportPath = Server.MapPath("~/Reports/Report.rdlc");

        //    ReportDataSource reportDataSource = new ReportDataSource();
        //    reportDataSource.Name = "UrlDataSet";
        //    reportDataSource.Value = db.NGUOIDUNGs.ToList();

        //    localReport.DataSources.Add(reportDataSource);

        //    string reportType = ReportType;
        //    string mimeType;
        //    string encoding;
        //    string fileNameExtension = (ReportType == "Excel") ? "xlsx" : (ReportType == "Word" ? "doc" : "pdf");
        //    Warning[] warnings;
        //    string[] streams;
        //    byte[] renderedBytes;
        //    renderedBytes = localReport.Render(reportType, "", out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
        //    Response.AddHeader("content-disposition", "attachment; filename=Urls." + fileNameExtension);

        //    return File(renderedBytes, fileNameExtension);

        //}


    }
}