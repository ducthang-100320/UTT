using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        CECMSDbContext db;
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetChart3()
        {
            var lstData = new List<Chart3>();
            db = new CECMSDbContext();
            var result = (from a in db.tblCategories
                          join b in db.tblNews
                          on a.ID equals b.CateNewsID
                          into sg
                          select new
                          {
                              names = a.CateName,
                              values = sg.Where(x => x.ID != -1).Count()
                          }).ToList();
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }

    public class Chart3
    {

        public string names { get; set; }
        public int values { get; set; }



    }
}