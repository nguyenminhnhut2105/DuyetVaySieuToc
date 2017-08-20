using DuyetVaySieuToc.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DuyetVaySieuToc.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(NGUOIDUNGVAY nguoidungVay, THONGBAO thongBao, TINHTRANG tinhTrang)
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

            string content = System.IO.File.ReadAllText(Server.MapPath("~/Helpers/ThongTinMail.html"));
            content = content.Replace("{{HOTEN}}", nguoidungVay.HOTEN);
            content = content.Replace("{{SDT}}", nguoidungVay.SDT.ToString());
            content = content.Replace("{{CMND}}", nguoidungVay.CMND.ToString());
            content = content.Replace("{{DIACHI}}", nguoidungVay.DIACHI);            
            content = content.Replace("{{NGAYDANGKY}}", DateTime.Now.ToString());          
           
            return RedirectToAction("finish");
        }
        public ActionResult finish()
        {
            return View();
        }

        public void GuiEmail(string Title, string ToEmail, string FromEmail, string PassWord, string Content)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(ToEmail);
            mail.From = new MailAddress(ToEmail);
            mail.Subject = Title;
            mail.Body = Content;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
            (FromEmail, PassWord);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }

    }
}