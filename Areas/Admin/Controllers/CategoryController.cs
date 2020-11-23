using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Category
        [CustomAuthorize]
        public ActionResult Category()
        {
            var model = db.LoaiCongThucs.Where(x => x.TenLoaiCT != null).ToList();
            ViewBag.DS = model;
            return View(model);
        }
        [HttpGet]
        public ActionResult Category_detail(long id)
        {
            var model = db.CongThucs.Where(x => x.MaLoaiCongThuc == id).ToList();
            ViewBag.DS = model;
            return PartialView("Category_detail", model);
        }
        [HttpDelete]
        public ActionResult Delete_category(long id)
        {
            db.LoaiCongThucs.Remove(db.LoaiCongThucs.Find(id));
            db.SaveChanges();
            var list = db.CongThucs.Where(x => x.MaLoaiCongThuc == id).ToList();
            foreach (var item in list)
            {
                db.CongThucs.Remove(item);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Category_update(long id, string tenloaiCT)
        {
            var lct = db.LoaiCongThucs.Find(id);
            lct.TenLoaiCT = tenloaiCT;
            db.SaveChanges();
            return RedirectToAction("Category");
        }
        [HttpPost]
        public ActionResult Status(long id)
        {
            var ct = db.CongThucs.Find(id);
            if (ct.TrangThai == true) ct.TrangThai = false;
            else ct.TrangThai = true;
            ct.MaNguoiChinhSua = (Session["NguoiDung"] as NguoiDung).UserID;
            ct.NgayChinhSua = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Recipe");
        }
        [HttpPost]
        public ActionResult Tophot(long id)
        {
            var ct = db.CongThucs.Find(id);
            if (ct.TopHot == true) ct.TopHot = false;
            else ct.TopHot = true;
            ct.MaNguoiChinhSua = (Session["NguoiDung"] as NguoiDung).UserID;
            ct.NgayChinhSua = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Recipe");
        }
    }
}