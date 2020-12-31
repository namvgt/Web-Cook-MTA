using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class compareLuotxem : IComparer<CongThuc>
    {
        public int Compare(CongThuc x, CongThuc y)
        {
            return x.LuotXem.Value.CompareTo(y.LuotXem.Value);
        }
    }
    public class compareLuotxemBlog : IComparer<Blog>
    {
        public int Compare(Blog x, Blog y)
        {
            return x.LuotXem.Value.CompareTo(y.LuotXem.Value);
        }
    }
    public class GeneralController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin   
        [CustomAuthorize]
        public ActionResult Index()
        {
            ViewBag.ct = db.CongThucs.Count();
            ViewBag.blog = db.Blogs.Count();
            ViewBag.ph = db.PhanHois.Count() + db.TraLoi_PhanHoi.Count();
            var list = db.TruyCaps.Where(x => x.ThoiGian != null).ToList();
            int sotruycap = 0;
            List<DateTime> thoigian = new List<DateTime>();
            List<int> soluong = new List<int>();
            foreach(var item in list)
            {
                thoigian.Insert(0,item.ThoiGian.Value);
                soluong.Insert(0, item.SoTruyCap.Value);
                sotruycap = sotruycap + item.SoTruyCap.Value;
            }
            ViewBag.Sotruycap = sotruycap;
            ViewBag.thoigian = thoigian;
            ViewBag.truycap = soluong;
            var dsct = db.CongThucs.Where(x => x.TenCongThuc != null).ToList();
            dsct.Sort(new compareLuotxem());
            dsct.Reverse();
            ViewBag.dsct = dsct;
            var dsbg = db.Blogs.Where(x => x.TieuDe != null).ToList();
            dsbg.Sort(new compareLuotxemBlog());
            dsbg.Reverse();
            ViewBag.dsbg = dsbg;
            return View("Index");
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Admin_add()
        {
            return View();
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Admin_list()
        {
            var username = (Session["NguoiDung"] as NguoiDung).UserName;
            var model = db.NguoiDungs.Where(s => s.UserName != username).ToList();
            ViewBag.DS = model;
            return View(model);
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }     
        public ActionResult Register()
        {
            return View();
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult User_list()
        {
            var model = db.ThanhViens.Where(s => s.HoTen != null).ToList();
            ViewBag.DS = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Admin_add(NguoiDung nd)
        {
            if (ModelState.IsValid)
            {
                db.NguoiDungs.Add(nd);
                db.SaveChanges();
                return RedirectToAction("Admin_list");
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete_User(long id)
        {
            db.NguoiDungs.Remove(db.NguoiDungs.Find(id));
            db.SaveChanges();
            return RedirectToAction("Admin_list");
        }
        [HttpDelete]
        public ActionResult Delete_member(long id)
        {
            db.ThanhViens.Remove(db.ThanhViens.Find(id));
            db.SaveChanges();
            return RedirectToAction("User_list");
        }
    }
}