using DuyetVaySieuToc.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DuyetVaySieuToc.Models.BusinessModel
{
    public class AuthorizeBusiness : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["userid"] == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Home/Login");
                return;

            }
            int userId = int.Parse(HttpContext.Current.Session["userid"].ToString());
            string action = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + "Controller-" + filterContext.ActionDescriptor.ActionName;

            Model1 db = new Model1();
            var admin = db.NGUOIDUNGs.Where(n => n.MAND == userId && n.QUANTRI.Value != 0).SingleOrDefault();
            if (admin != null)
            {
                return;
            }
            var listquyen = from a in db.QUYENs
                            join b in db.CAPQUYENs
                            on a.MAQUYEN equals b.MAQUYEN
                            where b.MAND == userId
                            select a.TENQUYEN;
            if (!listquyen.Contains(action))
            {
                filterContext.Result = new RedirectResult("/Admin/Home/ThongBao");
                return;

            }

        }
    }
}