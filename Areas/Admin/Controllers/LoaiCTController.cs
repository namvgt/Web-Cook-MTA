using Mix_MTA2.Models;
using Mix_MTA2.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Mix_MTA2.Areas.Admin.Controllers
{
    public class LoaiCTController : Controller
    {
        // GET: Admin/LoaiCT
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44384/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/LCT").Result;
            if (response.IsSuccessStatusCode)
            {
                var model =
               response.Content.ReadAsAsync<IEnumerable<LoaiCongThuc>>().Result;
                return View(model);
            }
            return View();

        }
    }
}