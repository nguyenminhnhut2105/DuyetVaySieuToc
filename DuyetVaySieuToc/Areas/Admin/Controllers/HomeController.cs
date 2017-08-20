using DuyetVaySieuToc.Models.BusinessModel;
using DuyetVaySieuToc.Models.DataModel;
using DuyetVaySieuToc.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuyetVaySieuToc.Areas.Admin.Controllers
{
 
    public class HomeController : Controller
    {
        Model1 db = null;
        public HomeController()
        {
            db = new Model1();
        }
        [AuthorizeBusiness]
        // GET: Admin/Home
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
            ViewBag.Dachuyen = dachuyen.Count();
            ViewBag.Daduyet = daduyet.Count();
            ViewBag.Reject = reject.Count();
            ViewBag.Nocontact = nocontact.Count();
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string passMD5 = CommonMD5.EncryptMD5(username + password);
            var user = db.NGUOIDUNGs.SingleOrDefault(n => n.TAIKHOAN == username && n.MATKHAU == passMD5 && n.MALOAIND == 2 && n.KICHHOAT == 1);
            if (user != null)
            {
                Session["userid"] = user.MAND;
                Session["username"] = user.TAIKHOAN;
                Session["fullname"] = user.HOTEN;
                Session["taiKhoan"] = user;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền";

            return View();
        }
        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            return RedirectToAction("Login");
        }
        [AuthorizeBusiness]
        public ActionResult ThongBao()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Account(int? id)
        {
            NGUOIDUNG tamp = db.NGUOIDUNGs.Find(id);
            if (Session["taiKhoan"] == null)
            {
                return RedirectToAction("Index");
            }
            if (((NGUOIDUNG)Session["taiKhoan"]).MAND != tamp.MAND)
                return RedirectToAction("Index");
            return View(tamp);
        }
        [AuthorizeBusiness]
        public ActionResult UpdatePassWord()
        {
            return View();
        }
         [HttpPost]
        public string UpdatePassWord(int? User, string Pass, string NewPass)
        {
            if (Session["taiKhoan"] == null)
            {
                return "err";
            }
            var tv = db.NGUOIDUNGs.Find(Session["userid"]);
            if (tv != null)
            {
                if (tv.MATKHAU != CommonMD5.EncryptMD5(tv.TAIKHOAN + Pass))
                {
                    return "Sai mật khẩu cũ";
                    
                }
                    
                else
                {
                    tv.MATKHAU = CommonMD5.EncryptMD5(tv.TAIKHOAN + NewPass);
                    db.Entry(tv).State = System.Data.Entity.EntityState.Modified;
                    if (db.SaveChanges() == 1)
                        TempData["ThongBao"] = "Cập nhật thành công";
                    return "Cập nhật thành công";
                    
                }

            }
            return "Cập nhập thất bại";

        }
        [ChildActionOnly]
        public ActionResult _UpdatePass(int? user)
        {
            if (Session["taiKhoan"] == null)
            {
                return RedirectToAction("Index");
            }
            NGUOIDUNG tv = db.NGUOIDUNGs.Single(n => n.MAND == user);
            return PartialView(tv);
        }
        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView();
        }
        public ActionResult TaiKhoan()
        {
            return PartialView();
        }

    }
}