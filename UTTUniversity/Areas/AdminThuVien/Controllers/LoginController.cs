using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienTruongHoc.Areas.Admin.Models;

namespace ThuVienTruongHoc.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        TRUONGHOCDbContext db;

        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Login
        [HttpPost]
        public ActionResult Index( tblAccount model, FormCollection collection)
        {
            db =new TRUONGHOCDbContext();
            var item = db.tblAccounts.Where(x => x.AccoutName == model.AccoutName && x.Password == model.Password && x.Status == 1).FirstOrDefault();
            if (item != null)
            {
                if (item.DateIssued<DateTime.Now)
                {
                
                        return RedirectToAction("Index","Home");
                 
                   
                   
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