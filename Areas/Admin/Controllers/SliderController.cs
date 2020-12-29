using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Slider
        [CustomAuthorize]
        public ActionResult Index()
        {
            var list = db.Sliders.Where(x => x.TieuDe != null).ToList();
            ViewBag.list = list;
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(long id)
        {
            return View(db.Sliders.Find(id));
        }
        public ActionResult Detail(long id)
        {
            return View(db.Sliders.Find(id));
        }
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            db.Sliders.Remove(db.Sliders.Find(id));
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult Status(long id)
        {
            var slider = db.Sliders.Find(id);
            if (slider.TrangThai == true) slider.TrangThai = false;
            else slider.TrangThai = true;
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Slider slider)
        {
            db.Sliders.Add(slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Slider slider)
        {
            var sd = db.Sliders.Find(slider.MaSlider);
            sd.TieuDe = slider.TieuDe;
            sd.NoiDung = slider.NoiDung;
            sd.AnhMinhHoa = slider.AnhMinhHoa;
            sd.TrangThai = slider.TrangThai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}