using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class CoSoDaoTaoController : Controller
    {
        #region MyRegion
        CECMSDbContext db;
        #endregion
        // GET: Admin/CoSoDaoTao
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Cơ sở đào tạo";
            db = new CECMSDbContext();
            var model = db.tblCoSoes.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return  PartialView();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(tblCoSo model, FormCollection collection)
        {
            db.tblCoSoes.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "CoSoDaoTao");
        }
        [HttpGet]
        public ActionResult Edit(string Ma_CoSo)
        {
            db = new CECMSDbContext();
            var model = db.tblCoSoes.First(m => m.MA_COSO == Ma_CoSo);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblCoSo model, FormCollection collection)
        {
            db = new CECMSDbContext();


            var item = db.tblCoSoes.Find(model.MA_COSO);
            
            var Result = db.SaveChanges();

            if (Result >= 0)
            {
                ModelState.AddModelError("success", "Cập nhật dữ liệu thành công");
                return RedirectToAction("Index", "CoSoDaoTao");
            }
            else
            {
                ModelState.AddModelError("error", "Lỗi trong quá trình ghi dữ liệu");
                return View();
            }


        }
        public ActionResult Details(string MA_COSO)
        {
            db = new CECMSDbContext();
            var model = db.tblCoSoes.Find(MA_COSO);
            return PartialView(model);
        }
        public ActionResult Delete(string Ma_COSO)
        {
            try
            {
                db = new CECMSDbContext();
                //var ID = Convert.ToInt32(id);
                var item = db.tblCoSoes.Find(Ma_COSO);
                if (item != null)
                {
                    db.tblCoSoes.Remove(item);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "CoSoDaoTao");
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