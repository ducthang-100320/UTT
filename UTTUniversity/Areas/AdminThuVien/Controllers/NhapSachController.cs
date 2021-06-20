using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class NhapSachController : Controller
    {
        CECMSDbContext db;
        // GET: AdminThuVien/NhapSach
        public ActionResult Index()
        {
            db = new CECMSDbContext();
            var model = db.tblPhieuNhapSaches.Where(x => x.TRANG_THAI == 1).ToList();
            return View(model);
        }
    }
}