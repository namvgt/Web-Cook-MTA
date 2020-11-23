using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class FeedbackController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Feedback
        [CustomAuthorize]
        public ActionResult List()
        {
            var DS = db.PhanHois.Where(x => x.ID_user != null).ToList();
            ViewBag.DS = DS;
            return View(DS);
        }
        [CustomAuthorize]
        public ActionResult Detail(long id)
        {
            return View(db.PhanHois.Find(id));
        }
        public ActionResult Detail_(long id)
        {
            return View(db.TraLoi_PhanHoi.Find(id));
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            db.PhanHois.Remove(db.PhanHois.Find(id));
            db.SaveChanges();
            var list = db.TraLoi_PhanHoi.Where(x => x.MaPhanHoi == id);
            foreach(var item in list)
            {
                db.TraLoi_PhanHoi.Remove(item);
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        [HttpDelete]
        public ActionResult Delete_ans(long id)
        {
            db.TraLoi_PhanHoi.Remove(db.TraLoi_PhanHoi.Find(id));
            db.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Reply(TraLoi_PhanHoi tl)
        {
            tl.MaNguoiDung = (Session["NguoiDung"] as NguoiDung).UserID;
            tl.NgayDang = DateTime.Now;
            db.TraLoi_PhanHoi.Add(tl);
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult Feedback_detail(long id)
        {
            var ds = db.TraLoi_PhanHoi.Where(x => x.MaPhanHoi == id).ToList();
            ViewBag.DS = ds;
            return PartialView("Reply", ds);
        }
    }
}