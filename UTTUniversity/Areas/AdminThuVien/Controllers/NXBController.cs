using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienTruongHoc.Areas.Admin.Models;

namespace ThuVienTruongHoc.Areas.Admin.Controllers
{
    public class NXBController : Controller
    {
        TRUONGHOCDbContext db;
        // GET: Admin/NXB
        public ActionResult Index()
        {
            db = new TRUONGHOCDbContext();
            var model = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1).ToList();
            return View(model);
        }
        
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(tblNhaXuatBan model , FormCollection collection)
        {
            db = new TRUONGHOCDbContext();
            model.TRANGTHAI = 1;
            var item = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1).ToList();
            foreach (var itemNXB in item)
            {
                if (model.MA_NXB == itemNXB.MA_NXB)
                {
                    ModelState.AddModelError("", "Mã đã tồn tại");
                    break;
                }
                
            }

            if (ModelState.IsValid)
            {
              
                db.tblNhaXuatBans.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "NXB");
            }
            else
            {
                return View();
            }
           
            
        }
        public ActionResult Details(int id)
        {
            db = new TRUONGHOCDbContext();
            var model = db.tblNhaXuatBans.Find(id);
            return PartialView(model);
        }

        public ActionResult Edit(int id)
        {
          
            db = new TRUONGHOCDbContext();
            var model = db.tblNhaXuatBans.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblNhaXuatBan model , FormCollection collection)
        {
            db = new TRUONGHOCDbContext();
            var item = db.tblNhaXuatBans.Find(model.ID);

            item.TEN_NXB = model.TEN_NXB;
            item.MA_NXB = model.MA_NXB;
            item.DIA_CHI = model.DIA_CHI;
            item.GHI_CHU = model.GHI_CHU;
            item.SO_DTHOAI = model.SO_DTHOAI;

            var itemnxb = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1 && x.ID!=model.ID).ToList();
            foreach (var itemNXB in itemnxb)
            {
                if (item.MA_NXB == itemNXB.MA_NXB)
                {
                    ModelState.AddModelError("", "Mã đã tồn tại");
                    break;
                }

            }

            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("Index", "NXB");
            }
            else
            {
                return View( model);
            }
            
        }

        public ActionResult Delete(int id)
        {
            db = new TRUONGHOCDbContext();
            var item = db.tblNhaXuatBans.Find(id);
            if (item!=null)
            {
                db.tblNhaXuatBans.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index", "NXB");
            }
            else
            {
                return View();
            }
           
        }
    }
}