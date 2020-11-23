using Mix_MTA2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class LCTController : ApiController
    {
        private Model1 db = new Model1();
        // GET: api/LCT
        public IEnumerable<LoaiCongThuc> Get()
        {
            return db.LoaiCongThucs.Where(x => x.MaLoaiCongThuc == 1).ToList();
        }

        // GET: api/LCT/5
        public LoaiCongThuc Get(int id)
        {
            return db.LoaiCongThucs.Find(id);
        }

        // POST: api/LCT
        public void Post(LoaiCongThuc value)
        {
            db.LoaiCongThucs.Add(value);
            db.SaveChanges();
        }

        // PUT: api/LCT/5
        public void Put(int id, LoaiCongThuc value)
        {
            var lct = db.LoaiCongThucs.Find(id);
            lct.TenLoaiCT = value.TenLoaiCT;
            lct.TopHot = value.TopHot;
            db.SaveChanges();
        }

        // DELETE: api/LCT/5
        public void Delete(int id)
        {
            db.LoaiCongThucs.Remove(db.LoaiCongThucs.Find(id));
            db.SaveChanges();
        }
    }
}
