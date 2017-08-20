using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DuyetVaySieuToc.Models.DataModel;
using DuyetVaySieuToc.Models.BusinessModel;
using DuyetVaySieuToc.Models.ViewModel;
using ClosedXML.Excel;
using System.IO;

namespace DuyetVaySieuToc.Areas.Admin.Controllers
{
    [AuthorizeBusiness]
    public class QuanLyKhachHangVayController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            var chuaduyet = from nguoidungvay in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 1
                            select nguoidungvay;
            var daduyet = from nguoidungvay in db.NGUOIDUNGVAYs
                          join
                          tinhtrang in db.TINHTRANGs
                          on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                          where tinhtrang.TRANGTHAI == 2
                          select nguoidungvay;
            var reject = from nguoidungvay in db.NGUOIDUNGVAYs
                         join
                         tinhtrang in db.TINHTRANGs
                         on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                         where tinhtrang.TRANGTHAI == 3
                         select nguoidungvay;
            var nocontact = from nguoidungvay in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 4
                            select nguoidungvay;
            var dachuyen = from nguoidungvay in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 5
                            select nguoidungvay;
       
            ViewBag.Chuaduyet = chuaduyet.Count();
            ViewBag.Daduyet = daduyet.Count();
            ViewBag.Reject = reject.Count();
            ViewBag.Nocontact = nocontact.Count();
            ViewBag.Dachuyen = dachuyen.Count();
            return View();
        }

        public ActionResult Chuaduyet()
        {
            var chuaduyet = from nguoidungvay in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 1
                            orderby nguoidungvay.NGAYDANGKY descending
                            select new KhachHangVayViewModel
                            {
                                ID = nguoidungvay.ID,
                                SDT = nguoidungvay.SDT,
                                CMND = nguoidungvay.CMND,
                                DIACHI = nguoidungvay.DIACHI,
                                VAYTHEO = nguoidungvay.VAYTHEO,
                                TRANGTHAI = nguoidungvay.TRANGTHAI,
                                TINH = nguoidungvay.TINH,
                                GHICHU = nguoidungvay.GHICHU,
                                TINHTRANG = nguoidungvay.TINHTRANG,
                                TEAM = nguoidungvay.TEAM,
                                NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                                NGAYDUYET = nguoidungvay.NGAYDUYET,
                                HOTEN = nguoidungvay.HOTEN,
                            };
            ViewBag.Chuaduyet = chuaduyet.Count();
            return View(chuaduyet);
        }
        public ActionResult Finish()
        {
            var finish = from nguoidungvay in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 2
                            orderby nguoidungvay.NGAYDANGKY descending
                         select new KhachHangVayViewModel
                            {
                                ID = nguoidungvay.ID,
                                SDT = nguoidungvay.SDT,
                                CMND = nguoidungvay.CMND,
                                DIACHI = nguoidungvay.DIACHI,
                                VAYTHEO = nguoidungvay.VAYTHEO,
                                TRANGTHAI = nguoidungvay.TRANGTHAI,
                                TINH = nguoidungvay.TINH,
                                GHICHU = nguoidungvay.GHICHU,
                                TINHTRANG = nguoidungvay.TINHTRANG,
                                TEAM = nguoidungvay.TEAM,
                                NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                                NGAYDUYET = nguoidungvay.NGAYDUYET,
                                HOTEN = nguoidungvay.HOTEN,
                            };
            ViewBag.Finish = finish.Count();
            return View(finish);
        }
        public ActionResult Reject()
        {
            var reject = from nguoidungvay in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 3
                            orderby nguoidungvay.NGAYDANGKY descending
                         select new KhachHangVayViewModel
                            {
                                ID = nguoidungvay.ID,
                                SDT = nguoidungvay.SDT,
                                CMND = nguoidungvay.CMND,
                                DIACHI = nguoidungvay.DIACHI,
                                VAYTHEO = nguoidungvay.VAYTHEO,
                                TRANGTHAI = nguoidungvay.TRANGTHAI,
                                TINH = nguoidungvay.TINH,
                                GHICHU = nguoidungvay.GHICHU,
                                TINHTRANG = nguoidungvay.TINHTRANG,
                                TEAM = nguoidungvay.TEAM,
                                NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                                NGAYDUYET = nguoidungvay.NGAYDUYET,
                                HOTEN = nguoidungvay.HOTEN,
                            };
            ViewBag.Reject = reject.Count();
            return View(reject);
        }
        public ActionResult Nocontact()
        {
            var nocontact = from nguoidungvay in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 4
                            orderby nguoidungvay.NGAYDANGKY descending
                            select new KhachHangVayViewModel
                            {
                                ID = nguoidungvay.ID,
                                SDT = nguoidungvay.SDT,
                                CMND = nguoidungvay.CMND,
                                DIACHI = nguoidungvay.DIACHI,
                                VAYTHEO = nguoidungvay.VAYTHEO,
                                TRANGTHAI = nguoidungvay.TRANGTHAI,
                                TINH = nguoidungvay.TINH,
                                GHICHU = nguoidungvay.GHICHU,
                                TINHTRANG = nguoidungvay.TINHTRANG,
                                TEAM = nguoidungvay.TEAM,
                                NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                                NGAYDUYET = nguoidungvay.NGAYDUYET,
                                HOTEN = nguoidungvay.HOTEN,
                            };
            ViewBag.Nocontact = nocontact.Count();
            return View(nocontact);
        }
        public ActionResult Dachuyen()
        {
            var dachuyen = from nguoidungvay in db.NGUOIDUNGVAYs
                         join
                         tinhtrang in db.TINHTRANGs
                         on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                         where tinhtrang.TRANGTHAI == 5
                         orderby nguoidungvay.NGAYDANGKY descending
                         select new KhachHangVayViewModel
                         {
                             ID = nguoidungvay.ID,
                             SDT = nguoidungvay.SDT,
                             CMND = nguoidungvay.CMND,
                             DIACHI = nguoidungvay.DIACHI,
                             VAYTHEO = nguoidungvay.VAYTHEO,
                             TRANGTHAI = nguoidungvay.TRANGTHAI,
                             TINH = nguoidungvay.TINH,
                             GHICHU = nguoidungvay.GHICHU,
                             TINHTRANG = nguoidungvay.TINHTRANG,
                             TEAM = nguoidungvay.TEAM,
                             NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                             NGAYDUYET = nguoidungvay.NGAYDUYET,
                             HOTEN = nguoidungvay.HOTEN,
                         };
            ViewBag.Dachuyen = dachuyen.Count();
            return View(dachuyen);
        }
        public ActionResult Duyet(int? maId)
        {
            if (maId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.chuaduyet = (from nguoidungvay in db.NGUOIDUNGVAYs
                                 join
                                 tinhtrang in db.TINHTRANGs
                                 on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                                 where nguoidungvay.ID == maId
                                 orderby nguoidungvay.NGAYDANGKY
                                 select new InfoOrder
                                 {
                                     ID = nguoidungvay.ID,
                                     SDT = nguoidungvay.SDT,
                                     CMND = nguoidungvay.CMND,
                                     DIACHI = nguoidungvay.DIACHI,
                                     VAYTHEO = nguoidungvay.VAYTHEO,
                                     TRANGTHAI = tinhtrang.TRANGTHAI,
                                     TINH = nguoidungvay.TINH,
                                     GHICHU = nguoidungvay.GHICHU,
                                     TINHTRANG = nguoidungvay.TINHTRANG,
                                     TEAM = nguoidungvay.TEAM,
                                     NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                                     NGAYDUYET = tinhtrang.NGAYDUYET,
                                     HOTEN = nguoidungvay.HOTEN,
                                     MATINHTRANG = tinhtrang.MATINHTRANG,
                                 }).SingleOrDefault();

            IEnumerable<KhachHangVayViewModel> chuaduyet = from nguoidungvay in db.NGUOIDUNGVAYs
                                                           join
                                                           tinhtrang in db.TINHTRANGs
                                                           on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                                                           where nguoidungvay.ID == maId
                                                           orderby nguoidungvay.NGAYDANGKY
                                                           select new KhachHangVayViewModel
                                                           {
                                                               ID = nguoidungvay.ID,
                                                               SDT = nguoidungvay.SDT,
                                                               CMND = nguoidungvay.CMND,
                                                               DIACHI = nguoidungvay.DIACHI,
                                                               VAYTHEO = nguoidungvay.VAYTHEO,
                                                               TRANGTHAI = tinhtrang.TRANGTHAI,
                                                               TINH = nguoidungvay.TINH,
                                                               GHICHU = nguoidungvay.GHICHU,
                                                               TINHTRANG = nguoidungvay.TINHTRANG,
                                                               TEAM = nguoidungvay.TEAM,
                                                               NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                                                               NGAYDUYET = tinhtrang.NGAYDUYET,
                                                               HOTEN = nguoidungvay.HOTEN,
                                                               MATINHTRANG = tinhtrang.MATINHTRANG,
                                                               
                                                           };
            if (chuaduyet!= null)
            {

                
                return View();
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Duyet(KhachHangVayViewModel tinhtrang)
        {
            TINHTRANG tt = db.TINHTRANGs.Single(n => n.MATINHTRANG == tinhtrang.MATINHTRANG);
            tt.TRANGTHAI = tinhtrang.TRANGTHAI;
            tt.NGAYDUYET = DateTime.Now;
            db.SaveChanges();           
            return RedirectToAction("Index");
        }
        [HttpPost]
        public FileResult Export()
        {
            Model1 entities = new Model1();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("THÔNG TIN KHÁCH HÀNG VAY - CHƯA DUYỆT") });
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Mã khách hàng"),
                                            new DataColumn("Họ và tên"),
                                            new DataColumn("Số điện thoại"),
                                            new DataColumn("Chứng minh"),
                                            new DataColumn("Tôi có"),
                                            new DataColumn("Ngày đăng ký")
                                             });
            
                                            

            var customers = from customer in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on customer.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 1
                            orderby customer.NGAYDANGKY descending
                            select new KhachHangVayViewModel
                            {
                                ID = customer.ID,
                                SDT = customer.SDT,
                                CMND = customer.CMND,
                                DIACHI = customer.DIACHI,
                                VAYTHEO = customer.VAYTHEO,
                                TRANGTHAI = customer.TRANGTHAI,
                                TINH = customer.TINH,
                                GHICHU = customer.GHICHU,
                                TINHTRANG = customer.TINHTRANG,
                                TEAM = customer.TEAM,
                                NGAYDANGKY = customer.NGAYDANGKY,
                                NGAYDUYET = customer.NGAYDUYET,
                                HOTEN = customer.HOTEN,
                            };
            foreach (var customer in customers)
            {
                dt.Rows.Add("",customer.ID, customer.HOTEN, customer.SDT, customer.CMND, customer.VAYTHEO,customer.NGAYDANGKY);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "THONG_TIN_KHACH_HANG_CHUADUYET.xlsx");
                }
            }
        }
        [HttpPost]
        public FileResult ExportF()
        {
            Model1 entities = new Model1();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("THÔNG TIN KHÁCH HÀNG VAY - FINISH") });
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Mã khách hàng"),
                                            new DataColumn("Họ và tên"),
                                            new DataColumn("Số điện thoại"),
                                            new DataColumn("Chứng minh"),
                                            new DataColumn("Tôi có"),
                                            new DataColumn("Ngày đăng ký"),
                                            new DataColumn("Ngày xét duyệt")
                                             });



            var customers = from customer in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on customer.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 2
                            orderby customer.NGAYDANGKY descending
                            select new KhachHangVayViewModel
                            {
                                ID = customer.ID,
                                SDT = customer.SDT,
                                CMND = customer.CMND,
                                DIACHI = customer.DIACHI,
                                VAYTHEO = customer.VAYTHEO,
                                TRANGTHAI = customer.TRANGTHAI,
                                TINH = customer.TINH,
                                GHICHU = customer.GHICHU,
                                TINHTRANG = customer.TINHTRANG,
                                TEAM = customer.TEAM,
                                NGAYDANGKY = customer.NGAYDANGKY,
                                NGAYDUYET = tinhtrang.NGAYDUYET,
                                HOTEN = customer.HOTEN,
                            };
            foreach (var customer in customers)
            {
                dt.Rows.Add("", customer.ID, customer.HOTEN, customer.SDT, customer.CMND, customer.VAYTHEO, customer.NGAYDANGKY, customer.NGAYDUYET);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "THONG_TIN_KHACH_HANG_FINISH.xlsx");
                }
            }
        }
        [HttpPost]
        public FileResult ExportR()
        {
            Model1 entities = new Model1();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("THÔNG TIN KHÁCH HÀNG VAY - REJECT") });
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Mã khách hàng"),
                                            new DataColumn("Họ và tên"),
                                            new DataColumn("Số điện thoại"),
                                            new DataColumn("Chứng minh"),
                                            new DataColumn("Tôi có"),
                                            new DataColumn("Ngày đăng ký"),
                                             new DataColumn("Ngày xét duyệt")
                                             });



            var customers = from customer in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on customer.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 3
                            orderby customer.NGAYDANGKY descending
                            select new KhachHangVayViewModel
                            {
                                ID = customer.ID,
                                SDT = customer.SDT,
                                CMND = customer.CMND,
                                DIACHI = customer.DIACHI,
                                VAYTHEO = customer.VAYTHEO,
                                TRANGTHAI = customer.TRANGTHAI,
                                TINH = customer.TINH,
                                GHICHU = customer.GHICHU,
                                TINHTRANG = customer.TINHTRANG,
                                TEAM = customer.TEAM,
                                NGAYDANGKY = customer.NGAYDANGKY,
                                NGAYDUYET = tinhtrang.NGAYDUYET,
                                HOTEN = customer.HOTEN,
                            };
            foreach (var customer in customers)
            {
                dt.Rows.Add("", customer.ID, customer.HOTEN, customer.SDT, customer.CMND, customer.VAYTHEO, customer.NGAYDANGKY, customer.NGAYDUYET);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "THONG_TIN_KHACH_HANG_REJECT.xlsx");
                }
            }
        }
        [HttpPost]
        public FileResult ExportN()
        {
            Model1 entities = new Model1();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("THÔNG TIN KHÁCH HÀNG VAY - NO CONTACT") });
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Mã khách hàng"),
                                            new DataColumn("Họ và tên"),
                                            new DataColumn("Số điện thoại"),
                                            new DataColumn("Chứng minh"),
                                            new DataColumn("Tôi có"),
                                            new DataColumn("Ngày đăng ký"),
                                            new DataColumn("Ngày xét duyệt")
                                             });



            var customers = from customer in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on customer.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 4
                            orderby customer.NGAYDANGKY descending
                            select new KhachHangVayViewModel
                            {
                                ID = customer.ID,
                                SDT = customer.SDT,
                                CMND = customer.CMND,
                                DIACHI = customer.DIACHI,
                                VAYTHEO = customer.VAYTHEO,
                                TRANGTHAI = customer.TRANGTHAI,
                                TINH = customer.TINH,
                                GHICHU = customer.GHICHU,
                                TINHTRANG = customer.TINHTRANG,
                                TEAM = customer.TEAM,
                                NGAYDANGKY = customer.NGAYDANGKY,
                                NGAYDUYET = tinhtrang.NGAYDUYET,
                                HOTEN = customer.HOTEN,
                            };
            foreach (var customer in customers)
            {
                dt.Rows.Add("", customer.ID, customer.HOTEN, customer.SDT, customer.CMND, customer.VAYTHEO, customer.NGAYDANGKY, customer.NGAYDUYET);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "THONG_TIN_KHACH_HANG_NOCONTACT.xlsx");
                }
            }
        }
        [HttpPost]
        public FileResult ExportD()
        {
            Model1 entities = new Model1();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[1] { new DataColumn("THÔNG TIN KHÁCH HÀNG VAY - ĐÃ CHUYỂN") });
            dt.Columns.AddRange(new DataColumn[7] { new DataColumn("Mã khách hàng"),
                                            new DataColumn("Họ và tên"),
                                            new DataColumn("Số điện thoại"),
                                            new DataColumn("Chứng minh"),
                                            new DataColumn("Tôi có"),
                                            new DataColumn("Ngày đăng ký"),
                                            new DataColumn("Ngày xét duyệt")
                                             });



            var customers = from customer in db.NGUOIDUNGVAYs
                            join
                            tinhtrang in db.TINHTRANGs
                            on customer.MATINHTRANG equals tinhtrang.MATINHTRANG
                            where tinhtrang.TRANGTHAI == 5
                            orderby customer.NGAYDANGKY descending
                            select new KhachHangVayViewModel
                            {
                                ID = customer.ID,
                                SDT = customer.SDT,
                                CMND = customer.CMND,
                                DIACHI = customer.DIACHI,
                                VAYTHEO = customer.VAYTHEO,
                                TRANGTHAI = customer.TRANGTHAI,
                                TINH = customer.TINH,
                                GHICHU = customer.GHICHU,
                                TINHTRANG = customer.TINHTRANG,
                                TEAM = customer.TEAM,
                                NGAYDANGKY = customer.NGAYDANGKY,
                                NGAYDUYET = tinhtrang.NGAYDUYET,
                                HOTEN = customer.HOTEN,
                            };
            foreach (var customer in customers)
            {
                dt.Rows.Add("", customer.ID, customer.HOTEN, customer.SDT, customer.CMND, customer.VAYTHEO, customer.NGAYDANGKY, customer.NGAYDUYET);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "THONG_TIN_KHACH_HANG_DACHUYEN.xlsx");
                }
            }
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNGVAY nGUOIDUNGVAY = db.NGUOIDUNGVAYs.Find(id);
            if (nGUOIDUNGVAY == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNGVAY);
        }
        public ActionResult Creates()
        {
            
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creates(NGUOIDUNGVAY nguoidungVay, THONGBAO thongBao, TINHTRANG tinhTrang)
        {

            THONGBAO thongbao = new THONGBAO();
            thongbao.NOIDUNG = "Chờ duyệt";
            thongbao.NGAY = DateTime.Now;
            db.THONGBAOs.Add(thongbao);
            db.SaveChanges();

            TINHTRANG tinhtrang = new TINHTRANG();
            tinhtrang.TRANGTHAI = 1;
            tinhtrang.NGAYTAO = DateTime.Now;
            db.TINHTRANGs.Add(tinhtrang);
            db.SaveChanges();

            NGUOIDUNGVAY ndv = new NGUOIDUNGVAY();
            ndv.HOTEN = nguoidungVay.HOTEN;
            ndv.SDT = nguoidungVay.SDT;
            ndv.CMND = nguoidungVay.CMND;
            ndv.DIACHI = nguoidungVay.DIACHI;
            ndv.VAYTHEO = nguoidungVay.VAYTHEO;
            ndv.NGAYDANGKY = DateTime.Now;
            ndv.MATINHTRANG = tinhtrang.MATINHTRANG;
            ndv.MATHONGBAO = thongbao.MATHONGBAO;
            db.NGUOIDUNGVAYs.Add(ndv);
            db.SaveChanges();

            ViewBag.MATHONGBAO = new SelectList(db.THONGBAOs, "MATHONGBAO", "NOIDUNG");
            ViewBag.MATINHTRANG = new SelectList(db.TINHTRANGs, "MATINHTRANG", "GhiChu");
            return RedirectToAction("Index");
        }

        // GET: Admin/QuanLyKhachHangVay/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNGVAY nGUOIDUNGVAY = db.NGUOIDUNGVAYs.Find(id);
            IEnumerable<KhachHangVayViewModel> chuaduyet = from nguoidungvay in db.NGUOIDUNGVAYs
                                                           join
                                                           tinhtrang in db.TINHTRANGs
                                                           on nguoidungvay.MATINHTRANG equals tinhtrang.MATINHTRANG
                                                           where nguoidungvay.ID == id
                                                           orderby nguoidungvay.NGAYDANGKY
                                                           select new KhachHangVayViewModel
                                                           {
                                                               ID = nguoidungvay.ID,
                                                               SDT = nguoidungvay.SDT,
                                                               CMND = nguoidungvay.CMND,
                                                               DIACHI = nguoidungvay.DIACHI,
                                                               VAYTHEO = nguoidungvay.VAYTHEO,
                                                               TRANGTHAI = tinhtrang.TRANGTHAI,
                                                               TINH = nguoidungvay.TINH,
                                                               GHICHU = nguoidungvay.GHICHU,
                                                               TINHTRANG = nguoidungvay.TINHTRANG,
                                                               TEAM = nguoidungvay.TEAM,
                                                               NGAYDANGKY = nguoidungvay.NGAYDANGKY,
                                                               NGAYDUYET = tinhtrang.NGAYDUYET,
                                                               HOTEN = nguoidungvay.HOTEN,
                                                               MATINHTRANG = tinhtrang.MATINHTRANG,

                                                           };
            if (nGUOIDUNGVAY == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNGVAY);
        }

        // POST: Admin/QuanLyKhachHangVay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SDT,HOTEN,MATINHTRANG,MATHONGBAO,CMND,DIACHI,VAYTHEO,TRANGTHAI,TINH,GHICHU,TINHTRANG,TEAM,NGAYDANGKY,NGAYDUYET")] NGUOIDUNGVAY nGUOIDUNGVAY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nGUOIDUNGVAY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nGUOIDUNGVAY);
        }

        // GET: Admin/QuanLyKhachHangVay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NGUOIDUNGVAY nGUOIDUNGVAY = db.NGUOIDUNGVAYs.Find(id);
            if (nGUOIDUNGVAY == null)
            {
                return HttpNotFound();
            }
            return View(nGUOIDUNGVAY);
        }

        // POST: Admin/QuanLyKhachHangVay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NGUOIDUNGVAY nGUOIDUNGVAY = db.NGUOIDUNGVAYs.Find(id);
            db.NGUOIDUNGVAYs.Remove(nGUOIDUNGVAY);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
