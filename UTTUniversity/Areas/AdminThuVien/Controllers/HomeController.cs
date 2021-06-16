using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class HomeController : Controller
    {
        CECMSDbContext db;
        // GET: Admin/Home
        public ActionResult Index(/*int page = 1, int pageSize = 5*/ int id)
        {
            
            db = new CECMSDbContext();
            var model = db.tblAccounts.Where(x => x.ID == id).FirstOrDefault();
            Session["accountAdmin"] = model;

            var model1 = db.tblNhanViens.Where(x => x.Account_ID == model.ID).FirstOrDefault();
            Session["user"] = model1;
            //db = new TRUONGHOCDbContext();
            //double totalRecord = db.tblSaches.Where(x => x.TRANG_THAI == 1).Count();
            //ViewBag.Total = totalRecord;
            //ViewBag.Page = page;
            //int maxPage = 5 ;
            //double totalPage = 0;
            //totalPage = (double)Math.Ceiling(((decimal)(totalRecord / pageSize)));
            //ViewBag.TotalPage = totalPage;
            //ViewBag.MaxPage = maxPage;
            //ViewBag.First = 1;
            //ViewBag.Last = totalPage;
            //ViewBag.Next = page + 1;
            //ViewBag.Prev = page - 1;
            //var model = db.tblSaches.Where(x => x.TRANG_THAI == 1).OrderByDescending(x=>x.ID).Skip((page -1)* pageSize).Take(pageSize).ToList(); 
            return View(/*model*/);
        }
    }
}