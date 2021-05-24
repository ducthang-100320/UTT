using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class PhongBanController : Controller
    {
        #region MyRegion
        CECMSDbContext db;
        #endregion
        // GET: Admin/PhongBan
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Phòng Ban";
            db = new CECMSDbContext();
            var model = db.tblPhongBans.ToList();
            return View(model);
        }
    }
}