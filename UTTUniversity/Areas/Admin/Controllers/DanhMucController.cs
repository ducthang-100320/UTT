using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class DanhMucController : Controller
    {
        CECMSDbContext db;
        // GET: Admin/DanhMuc
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Danh Mục";
            db = new CECMSDbContext();
            var model = db.tblCategories.ToList();
            return View(model);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            setCombobox();
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblCategory model, FormCollection collection)
        {

            model.ParentID = -1;
            
            
            model.Status = 1;
            model.ModifiedDate = DateTime.Now;
            model.CreatedUser = "ducthang";
            model.ModifiedUser = "ducthang";
            model.ModifiedDate = DateTime.Now;
            if (ModelState.IsValid == true)
            {
                db = new CECMSDbContext();
                db.tblCategories.Add(model);
                var result = db.SaveChanges();
                return RedirectToAction("Index", "DanhMuc");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi Dữ Liệu");
                setCombobox();
                return View();
            }


        }
        public void setCombobox()
        {
            db = new CECMSDbContext();
            var model = db.tblCategories.Where(x =>  x.Status == 1).ToList();
            ViewBag.Menu = model;
        }
        public ActionResult Delete(int id)
        {
            try
            {
                db = new CECMSDbContext();
                //var ID = Convert.ToInt32(id);
                var item = db.tblCategories.Find(id);
                if (item != null)
                {
                    db.tblCategories.Remove(item);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "DanhMuc");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            db = new CECMSDbContext();
            var model = db.tblCategories.Find(id);
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            setCombobox();
            db = new CECMSDbContext();
            var model = db.tblCategories.First(m => m.ID == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(tblCategory model, FormCollection collection)
        {
            setCombobox();
            try
            {
                ModelState["Location"].Errors.Clear();
                if (ModelState.IsValid == true)
                {
                    db = new CECMSDbContext();
                    var item = db.tblCategories.Find(model.ID);
                    item.CateName = model.CateName;
                    
                    item.ParentID = -1;
                    item.OrderNumber = model.OrderNumber;
                    item.Description = model.Description;
                    item.CreatedDate = model.CreatedDate;
                    item.CreatedUser = model.CreatedUser;
                    item.ModifiedDate = model.ModifiedDate;
                    item.ModifiedUser = model.ModifiedUser;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "DanhMuc");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        public ActionResult Modal()
        {
            return PartialView();
        }
    }
}