using Mix_MTA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;
using PagedList;
using System.Security.Cryptography;

namespace Mix_MTA2.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        // =================================================================================================== Trang chủ
        public ActionResult Index()
        {
            var sl = db.Sliders.Where(x => x.TieuDe != null).ToList();
            var kq = db.CongThucs.Where(x => x.TopHot == true).ToList();
            var kq2 = db.CongThucs.Where(x => x.TopHot == false).ToList();
            var kq3 = db.LoaiCongThucs.Where(x => x.TopHot == true).ToList();
            ViewBag.slide = sl;
            ViewBag.list_lct = kq3;
            ViewBag.list_top = kq;
            ViewBag.list_nm = kq2;
            //Session["ThanhVien"] = null;
            if (Session["ThanhVien1"] == null)
            {
                //Session["ThanhVien"] = db.ThanhViens.Where(x=>x.ID_user != 0).FirstOrDefault();
                Session["ThanhVien"] = null;
            }
            else
            {
                Session["ThanhVien"] = Session["ThanhVien1"];
            }
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        // =================================================================================================== Tìm kiếm công thức
        public ActionResult Timkiem()
        {
            var tk = db.CongThucs.Where(x => x.TenCongThuc != null).ToList();
            ViewBag.DS = tk;
            return View(tk);
        }

        // =================================================================================================== Tìm kiếm công thức
        [HttpPost]
        public ActionResult Timkiem(string Noidung)
        {
            var tk = db.CongThucs.Where(x => x.TenCongThuc.Contains(Noidung) || x.TieuDe.Contains(Noidung)).ToList();
            ViewBag.DS = tk;
            return View("Timkiem", tk);
        }
        // =================================================================================================== Tìm kiếm theo độ khó
        public ActionResult Timkiem_in(int dk)
        {
            var tk = db.CongThucs.Where(x => x.DoKho == dk).ToList();
            ViewBag.DS = tk;
            return View("Timkiem", tk);
        }
        // =================================================================================================== tìm kiếm theo loại công thức
        public ActionResult Timkiem_in2(int id_lct)
        {
            var tk = db.CongThucs.Where(x => x.MaLoaiCongThuc == id_lct).ToList();
            ViewBag.DS = tk;
            return View("Timkiem", tk);
        }
        public ActionResult Contact()
        {
            return View();
        }
        // =================================================================================================== Danh sách công thức
        public ActionResult Receipt()
        {
            var model = db.CongThucs.Where(x => x.ID_congthuc != 0).ToList();
            ViewBag.DS = model;
            return View(model);
        }
        // =================================================================================================== Phân loại công thức
        public ActionResult Phanloai(int id_lct)
        {
            var model = db.CongThucs.Where(x => x.MaLoaiCongThuc == id_lct).ToList();
            ViewBag.DS = model;
            return View("Receipt", model);
        }
        // =================================================================================================== Blog
        public ActionResult Blog(int? page)
        {
            //if (page == null)
            //{
            //    page = 1;
            //}
            var model = db.Blogs.Where(x => x.MaBlog != 0).Take(3);
            ViewBag.list = model;
            var User_ = db.NguoiDungs.Where(x => x.UserID != 0).ToList();
            ViewBag.list_us = User_;
            //var page_ = (from l in db.Blogs select l).OrderBy(x => x.MaBlog);
            //int pageSize = 3;
            //int pageNumber = (page ?? 1);
            //return View(page_.ToPagedList(pageNumber, pageSize));
            return View(model);
        }
        // =================================================================================================== Chi tiết công thức
        public ActionResult Chitietcongthuc(int id)
        {
            var ct = db.NoiDungCTs.Where(x => x.MaCongThuc == id).ToList();
            ViewBag.ctiet = ct;
            var nl = db.NguyenLieux.Where(x => x.MaCongThuc == id).ToList();
            ViewBag.tp = nl;
            var review = db.Reviews.Where(x => x.ID_congthuc == id).ToList();
            ViewBag.rv = review;
            var congthuc = db.CongThucs.Where(x => x.ID_congthuc == id).FirstOrDefault();
            Session["Ctiet"] = congthuc;
            var traloi = db.View_traloi.Where(x => x.MaTraLoi != 0).ToList();
            ViewBag.Answer = traloi;
            return View(congthuc);
        }
        // =================================================================================================== Chi tiết blog
        public ActionResult ChitietBlog(int id)
        {
            var blog = db.Blogs.Where(x => x.MaBlog == id).FirstOrDefault();
            var noidung = db.NoiDung_Blog.Where(x => x.ID_blog == id).ToList();
            ViewBag.nd = noidung;
            var review = db.Reviews.Where(x => x.ID_blog == id).ToList();
            ViewBag.rv_bl = review;
            Session["Ctiet_Blog"] = blog;
            var traloi = db.View_traloi.Where(x => x.MaTraLoi != 0).ToList();
            ViewBag.Answer = traloi;
            return View(blog);
        }
        // =================================================================================================== Tìm kiếm trong blog
        public ActionResult Timkiem_blog(string noidung)
        {
            var tk = db.Blogs.Where(x => x.TieuDe.Contains(noidung) || x.TenBlog.Contains(noidung)).ToList();
            ViewBag.list = tk;
            var User_ = db.NguoiDungs.Where(x => x.UserID != 0).ToList();
            ViewBag.list_us = User_;
            return View("Blog", tk);
        }
        // =================================================================================================== Đăng ký
        public ActionResult Dangky(ThanhVien mber)
        {
            if (ModelState.IsValid)
            {
                var mber_old = db.ThanhViens.Where(x => x.Username == mber.Username).FirstOrDefault();
                if (mber_old == null)
                {
                    mber.NgayDangky = DateTime.Now;
                    mber.HinhDaiDien = "bdv.jpg";
                    db.ThanhViens.Add(mber);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản này đã tồn tại!");
                }
            }
            return RedirectToAction("Login");
        }
        // ========================================================================================Đăng nhập
        public ActionResult Login()
        {
            return View();
        }

        // ========================================================================================Đăng nhập
        [HttpPost]
        public ActionResult Login(string Username, string password)
        {
            if (ModelState.IsValid)
            {
                var data = db.ThanhViens.Where(s => s.Username.Equals(Username) && s.PassWord.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    Session["ThanhVien1"] = db.ThanhViens.Where(x => x.Username == Username).FirstOrDefault();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thông tin đăng nhập không đúng");
                }
            }
            return View();
        }
        // ========================================================================================Thông tin cá nhân
        public ActionResult Profile_(int id)
        {
            var tv = db.ThanhViens.Where(x => x.ID_user == id).FirstOrDefault();
            return View(tv);
        }

        // ==============================================================================Phản hồi trang web
        public ActionResult P_hoi_web(string noidung)
        {
            if (ModelState.IsValid)
            {
                PhanHoi phanhoi = new PhanHoi();
                if (Session["ThanhVien"] != null)
                {
                    if (noidung != null)
                    {
                        ThanhVien tv = Session["ThanhVien"] as ThanhVien;
                        phanhoi.ID_user = tv.ID_user;
                        phanhoi.NgayDang = DateTime.Now;
                        phanhoi.TieuDe = null;
                        phanhoi.NoiDung = noidung;
                        db.PhanHois.Add(phanhoi);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn chưa nhập nội dung!");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn cần đăng nhập để gửi phản hồi!");

                }
            }

            return RedirectToAction("Login");
        }

        // ==============================================================================Phản hồi công thức
        public ActionResult P_hoi(string noidung)
        {
            if (ModelState.IsValid)
            {
                PhanHoi phanhoi = new PhanHoi();
                if (Session["ThanhVien"] != null)
                {
                    if (noidung != null)
                    {
                        ThanhVien tv = Session["ThanhVien"] as ThanhVien;
                        CongThuc ct = Session["Ctiet"] as CongThuc;
                        phanhoi.ID_congthuc = ct.ID_congthuc;
                        phanhoi.ID_user = tv.ID_user;
                        phanhoi.NgayDang = DateTime.Now;
                        phanhoi.TieuDe = null;
                        phanhoi.NoiDung = noidung;
                        db.PhanHois.Add(phanhoi);
                        db.SaveChanges();
                        return RedirectToAction("Receipt");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn chưa nhập nội dung!");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn cần đăng nhập để gửi phản hồi!");

                }
            }

            return RedirectToAction("Login");
        }
        //=========================================================================== Phản hồi blog
        public ActionResult P_hoi_blog(string noidung)
        {
            if (ModelState.IsValid)
            {
                PhanHoi phanhoi = new PhanHoi();
                if (Session["ThanhVien"] != null)
                {
                    if (noidung != null)
                    {
                        ThanhVien tv = Session["ThanhVien"] as ThanhVien;
                        Blog blg = Session["Ctiet_Blog"] as Blog;
                        phanhoi.ID_blog = blg.MaBlog;
                        phanhoi.ID_user = tv.ID_user;
                        phanhoi.NgayDang = DateTime.Now;
                        phanhoi.TieuDe = null;
                        phanhoi.NoiDung = noidung;
                        db.PhanHois.Add(phanhoi);
                        db.SaveChanges();
                        return RedirectToAction("Blog");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn chưa nhập nội dung!");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn cần đăng nhập để gửi phản hồi!");

                }
            }

            return RedirectToAction("Login");
        }
        //=========================================================================== trả lời phản hồi blog
        public ActionResult Traloi_ph_hoi_cthuc(int id, string noidung)
        {
            if (ModelState.IsValid)
            {
                TraLoi_PhanHoi trl = new TraLoi_PhanHoi();
                if (Session["ThanhVien"] != null)
                {
                    if (noidung != null)
                    {
                        ThanhVien tv = Session["ThanhVien"] as ThanhVien;
                        trl.MaThanhVien = tv.ID_user;
                        trl.NoiDung = noidung;
                        trl.MaPhanHoi = id;
                        trl.NgayDang = DateTime.Now;
                        db.TraLoi_PhanHoi.Add(trl);
                        db.SaveChanges();
                        return RedirectToAction("Receipt");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn chưa nhập nội dung!");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn cần đăng nhập để gửi phản hồi!");

                }
            }

            return RedirectToAction("Login");
        }
        //========================================================================================== Trả lời phản hồi blog
        public ActionResult Traloi_ph_hoi_blog(int id, string noidung)
        {
            if (ModelState.IsValid)
            {
                TraLoi_PhanHoi trl = new TraLoi_PhanHoi();
                if (Session["ThanhVien"] != null)
                {
                    if (noidung != null)
                    {
                        ThanhVien tv = Session["ThanhVien"] as ThanhVien;
                        trl.MaThanhVien = tv.ID_user;
                        trl.NoiDung = noidung;
                        trl.MaPhanHoi = id;
                        trl.NgayDang = DateTime.Now;
                        db.TraLoi_PhanHoi.Add(trl);
                        db.SaveChanges();
                        return RedirectToAction("Blog");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Bạn chưa nhập nội dung!");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Bạn cần đăng nhập để gửi phản hồi!");

                }
            }

            return RedirectToAction("Login");
        }
    }
}