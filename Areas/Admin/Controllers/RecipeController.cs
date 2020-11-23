using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class RecipeController : Controller
    {
        private Model1 db = new Model1();
        // GET: Admin/Recipe
        [CustomAuthorize]
        public ActionResult Recipe()
        {
            var model = db.CongThucs.Where(s => s.TieuDe != null).ToList();
            ViewBag.DS = model;
            return View(model);
        }
        [CustomAuthorize]
        public ActionResult Recipe_edit(int id)
        {
            CongThuc ct = new CongThuc();
            ct = db.CongThucs.Find(id);
            var model = db.LoaiCongThucs.Where(x => x.TenLoaiCT != null);
            ViewBag.DS = model;
            return View(ct);
        }
        [CustomAuthorize]
        public ActionResult Recipe_add()
        {
            var model = db.LoaiCongThucs.Where(x => x.TenLoaiCT != null).ToList();
            ViewBag.DS = model;
            return View(model);
        }
        [CustomAuthorize]
        public ActionResult Recipe_detail(long id)
        {
            var ct = db.CongThucs.Find(id);
            return View(ct);
        }
        [HttpPost]
        public ActionResult Recipe_edit(CongThuc ct, long[] maNL, string[] NL, string[] SL, long[] maND, string[] NoiDung, string LoaiCongThuc)
        {
            CongThuc congthuc = new CongThuc();
            congthuc = db.CongThucs.Find(ct.ID_congthuc);
            congthuc.TenCongThuc = ct.TenCongThuc;
            congthuc.AnhMinhHoa = ct.AnhMinhHoa;
            congthuc.DoKho = ct.DoKho;
            congthuc.TieuDe = ct.TieuDe;
            congthuc.ThoiGianCB = ct.ThoiGianCB;
            congthuc.ThoiGianNau = ct.ThoiGianNau;
            congthuc.MaLoaiCongThuc = db.LoaiCongThucs.FirstOrDefault(x => x.TenLoaiCT == LoaiCongThuc).MaLoaiCongThuc;
            congthuc.TopHot = ct.TopHot;
            congthuc.TrangThai = ct.TrangThai;
            congthuc.NgayChinhSua = DateTime.Now;
            NguoiDung nd = (NguoiDung)Session["NguoiDung"];
            ct.MaNguoiChinhSua = nd.UserID;
            db.SaveChanges();
            for (int i = 0; i < maNL.Count(); i++)
            {
                if (maNL[i] != 0)
                {
                    var nl = db.NguyenLieux.Find(maNL[i]);
                    nl.TenNguyenLieu = NL[i];
                    nl.SoLuong = SL[i];
                    db.SaveChanges();
                }
                else
                {
                    var nl = new NguyenLieu();
                    nl.MaCongThuc = ct.ID_congthuc;
                    nl.SoLuong = SL[i];
                    nl.TenNguyenLieu = NL[i];
                    db.NguyenLieux.Add(nl);
                    db.SaveChanges();
                }
            }
            for (int i = 0; i < NoiDung.Count(); i++)
            {
                if (maND[i] != 0)
                {
                    var noidung = db.NoiDungCTs.Find(maND[i]);
                    noidung.NoiDung = NoiDung[i];
                    db.SaveChanges();
                }
                else
                {
                    var noidung = new NoiDungCT();
                    noidung.MaCongThuc = ct.ID_congthuc;
                    noidung.NoiDung = NoiDung[i];
                    db.NoiDungCTs.Add(noidung);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Recipe");
        }
        [HttpPost]
        public ActionResult Recipe_add(CongThuc ct, string LoaiCongThuc, string[] NL, string[] SL, string[] NoiDung)
        {
            NguoiDung nd = (NguoiDung)Session["NguoiDung"];
            var lct = db.LoaiCongThucs.FirstOrDefault(x => x.TenLoaiCT == LoaiCongThuc);
            ct.MaLoaiCongThuc = lct.MaLoaiCongThuc;
            ct.MaNguoiTao = nd.UserID;
            ct.NgayTao = DateTime.Now;
            db.CongThucs.Add(ct);
            db.SaveChanges();
            for (int i = 0; i < NL.Count(); i++)
            {
                if (NL[i] != null)
                {
                    NguyenLieu nl = new NguyenLieu();
                    nl.MaCongThuc = db.CongThucs.FirstOrDefault(x => x.TenCongThuc == ct.TenCongThuc).ID_congthuc;
                    nl.TenNguyenLieu = NL[i];
                    nl.SoLuong = SL[i];
                    db.NguyenLieux.Add(nl);
                }
            }
            for (int i = 0; i < NoiDung.Count(); i++)
            {
                if (NoiDung[i] != null)
                {
                    NoiDungCT ndct = new NoiDungCT();
                    ndct.MaCongThuc = db.CongThucs.FirstOrDefault(x => x.TenCongThuc == ct.TenCongThuc).ID_congthuc;
                    ndct.NoiDung = NoiDung[i];
                    db.NoiDungCTs.Add(ndct);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Recipe");
        }
        [HttpDelete]
        public ActionResult Delete_recipe(long ID_CongThuc)
        {
            var nd = db.NoiDungCTs.Where(x => x.MaCongThuc == ID_CongThuc).ToList();
            foreach (var it in nd)
            {
                db.NoiDungCTs.Remove(it);
            }
            var nl = db.NguyenLieux.Where(x => x.MaCongThuc == ID_CongThuc).ToList();
            foreach (var it in nl)
            {
                db.NguyenLieux.Remove(it);
            }
            var ct = db.CongThucs.Find(ID_CongThuc);
            db.CongThucs.Remove(ct);
            db.SaveChanges();
            return RedirectToAction("Recipe");
        }
        [HttpDelete]
        public ActionResult Delete_nguyenlieu(long id)
        {
            db.NguyenLieux.Remove(db.NguyenLieux.Find(id));
            db.SaveChanges();
            return View();
        }
        [HttpDelete]
        public ActionResult Delete_ND(long id)
        {
            db.NoiDungCTs.Remove(db.NoiDungCTs.Find(id));
            db.SaveChanges();
            return View();
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