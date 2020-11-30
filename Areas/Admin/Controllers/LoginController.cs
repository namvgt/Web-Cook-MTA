using Mix_MTA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View("Login");
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var data = db.NguoiDungs.Where(s => s.UserName.Equals(UserName) && s.Password.Equals(Password)).ToList();
                if (data.Count() > 0)
                {
                    NguoiDung user = db.NguoiDungs.FirstOrDefault(x => x.UserName == UserName);
                    Session["NguoiDung"] = user;
                    return RedirectToAction("Index","General");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập không đúng");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Confirm_logout()
        {
            return View();
        }
    }
}