using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblAccount model, FormCollection collection)
        {
            CECMSDbContext db = new CECMSDbContext();
            var item = db.tblAccounts.Where(x => x.AccoutName == model.AccoutName && x.Password == model.Password && x.Status == 1).FirstOrDefault();
            if (item != null)
            {
                if (item.DateIssued < DateTime.Now)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Hết hiệu lực");
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