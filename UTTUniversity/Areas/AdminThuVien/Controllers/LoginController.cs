using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class LoginController : Controller
    {
        // GET: AdminThuVien/Login
        CECMSDbContext db;

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Login
        [HttpPost]
        public ActionResult Index(tblAccount model, FormCollection collection)
        {
            db = new CECMSDbContext();
            var item = db.tblAccounts.Where(x => x.AccoutName == model.AccoutName && x.Password == model.Password && x.Status == 1).FirstOrDefault();
            if (item != null)
            {
                if (item.DateIssued < DateTime.Now)
                {

                    return RedirectToAction("Index", "Home");



                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hết hiệu lực");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Thông tin tài khoản hoặc mật khẩu không chính xác");
                return View();
            }

        }
    }
}