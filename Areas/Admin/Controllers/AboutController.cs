using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    [CustomAuthorize]
    public class AboutController : Controller
    {
        // GET: Admin/About
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            var list = db.GioiThieux.Where(x => x.TieuDe != null);
            ViewBag.DS = list;
            return View();
        }
        public ActionResult Detail(long id)
        {
            return View();
        }
        public ActionResult Edit(long id)
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            db.GioiThieux.Remove(db.GioiThieux.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(GioiThieu gt)
        {
            db.GioiThieux.Add(gt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(GioiThieu gt)
        {
            var gioithieu = db.GioiThieux.Find(gt.MaGioiThieu);
            gioithieu = gt;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Status(long id)
        {
            var gt = db.GioiThieux.Find(id);
            if (gt.TrangThai == true) gt.TrangThai = false;
            else gt.TrangThai = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}