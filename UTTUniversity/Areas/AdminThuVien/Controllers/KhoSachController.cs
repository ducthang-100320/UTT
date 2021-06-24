using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class KhoSachController : Controller
    {
        CECMSDbContext db;
        // GET: AdminThuVien/KhoSach
        public ActionResult Index()
        {
           
           
            return View();
        }
    }
}