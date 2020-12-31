using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Blog
        [CustomAuthorize]
        public ActionResult Blog_list()
        {
            var model = db.Blogs.Where(x => x.TenBlog != null).ToList();
            ViewBag.DS = model;
            return View("Blog_list", model);
        }
        [CustomAuthorize]
        public ActionResult Blog_add()
        {
            return View();
        }
        [CustomAuthorize]
        public ActionResult Blog_edit(long id)
        {
            var blog = db.Blogs.Find(id);
            return View(blog);
        }
        [CustomAuthorize]
        public ActionResult Blog_detail(long id)
        {
            var blog = db.Blogs.Find(id);
            var user = db.NguoiDungs.Find(blog.MaNguoiTao);
            ViewBag.UserCre = user;
            if (blog.MaNguoiChinhSua != null)
            {
                var userEdit = db.NguoiDungs.Find(blog.MaNguoiChinhSua);
                ViewBag.UserEdit = userEdit;
            }
            return View(blog);
        }
        [HttpDelete]
        public ActionResult Delete_blog(long id)
        {
            var list = db.NoiDung_Blog.Where(x => x.ID_blog == id).ToList();
            foreach (var item in list)
            {
                db.NoiDung_Blog.Remove(item);
                db.SaveChanges();
            }
            db.Blogs.Remove(db.Blogs.Find(id));
            db.SaveChanges();
            return RedirectToAction("Blog_list");
        }
        [HttpDelete]
        public ActionResult Delete_ND_blog(long id)
        {
            db.NoiDung_Blog.Remove(db.NoiDung_Blog.FirstOrDefault(x => x.ID == id));
            db.SaveChanges();
            return View();
        }
        [HttpPost]
        public ActionResult Blog_add(Blog bg, string[] TieuDe_nd, string[] NoiDung)
        {
            bg.MaNguoiTao = (Session["NguoiDung"] as NguoiDung).UserID;
            bg.NgayTao = DateTime.Now;
            db.Blogs.Add(bg);
            db.SaveChanges();
            for (int i = 0; i < TieuDe_nd.Count(); i++)
            {
                if (TieuDe_nd[i] != null && NoiDung[i] != null)
                {
                    var id = db.Blogs.FirstOrDefault(x => x.TenBlog == bg.TenBlog).MaBlog;
                    NoiDung_Blog nd = new NoiDung_Blog();
                    nd.ID_blog = id;
                    nd.TieuDe = TieuDe_nd[i];
                    nd.NoiDung = NoiDung[i];
                    db.NoiDung_Blog.Add(nd);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Blog_list");
        }
        [HttpPost]
        public ActionResult Blog_edit(Blog bg, long[] maND, string[] _TieuDe, string[] NoiDung, string[] _AnhMinhHoa)
        {
            var blog = db.Blogs.Find(bg.MaBlog);
            if (bg.AnhMinhHoa == null)
            {
                bg.AnhMinhHoa = blog.AnhMinhHoa;
            }
            blog = bg;
            blog.MaNguoiChinhSua = (Session["NguoiDung"] as NguoiDung).UserID;
            blog.NgayChinhSua = DateTime.Now;
            db.SaveChanges();
            for (int i = 0; i < maND.Count(); i++)
            {
                if (maND[i] == 0 && (_TieuDe[i] != null || NoiDung[i] != null))
                {
                    var nd = new NoiDung_Blog();
                    nd.TieuDe = _TieuDe[i];
                    nd.NoiDung = NoiDung[i];
                    nd.AnhMinhHoa = _AnhMinhHoa[i];
                    nd.ID_blog = bg.MaBlog;
                    db.NoiDung_Blog.Add(nd);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Blog_list");
        }
        [HttpPost]
        public ActionResult Status(long id)
        {
            var blog = db.Blogs.Find(id);
            if (blog.TrangThai == true) blog.TrangThai = false;
            else blog.TrangThai = true;
            blog.MaNguoiChinhSua = (Session["NguoiDung"] as NguoiDung).UserID;
            blog.NgayChinhSua = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Blog_list");
        }
        public ActionResult Tophot(long id)
        {
            var blog = db.Blogs.Find(id);
            if (blog.TopHot == true) blog.TopHot = false;
            else blog.TopHot = true;
            blog.MaNguoiChinhSua = (Session["NguoiDung"] as NguoiDung).UserID;
            blog.NgayChinhSua = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Blog_list");
        }
    }
}