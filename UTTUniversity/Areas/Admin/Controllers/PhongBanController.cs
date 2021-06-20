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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblPhongBan model, FormCollection collection)
        {

            
            if (ModelState.IsValid == true)
            {
                db = new CECMSDbContext();
                var phongban = db.tblPhongBans.Where(x => x.MA_PHONGBAN.Equals(model.MA_PHONGBAN) || x.TEN_PHONGBAN.Equals(model.TEN_PHONGBAN)).ToList();
                foreach (var itempb in phongban)
                {
                    if (model.MA_PHONGBAN.Equals(itempb.MA_PHONGBAN))
                    {
                        ViewBag.Error = "Mã phòng ban đã tồn tại";
                        return View();
                    }
                    else if (model.TEN_PHONGBAN.Equals(itempb.TEN_PHONGBAN))
                    {
                        ViewBag.ErrorName = "Tên phòng ban đã tồn tại";
                        return View();
                    }
                }
                db.tblPhongBans.Add(model);
                var result = db.SaveChanges();
                return RedirectToAction("Index", "PhongBan");
            }
            else
            {
                ModelState.AddModelError("", "Lỗi Dữ Liệu");
                return View();
            }


        }
        public ActionResult Edit(string id)
        {
            db = new CECMSDbContext();
            var model = db.tblPhongBans.First(m => m.MA_PHONGBAN == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblPhongBan model, FormCollection collection)
        {
            db = new CECMSDbContext();

            
            var item = db.tblPhongBans.Find(model.MA_PHONGBAN);
            item.MA_PHONGBAN = model.MA_PHONGBAN;
            item.TEN_PHONGBAN = model.TEN_PHONGBAN;
            item.SO_DTHOAI = model.SO_DTHOAI;
            item.DIA_CHI = model.DIA_CHI;
            item.MO_TA = model.MO_TA;
            item.GHI_CHU = model.GHI_CHU;

            var Result = db.SaveChanges();

            if (Result >= 0)
            {
                ViewBag.Success = "Cập nhật dữ liệu thành công";
                return RedirectToAction("Index", "PhongBan");
            }
            else
            {
                ModelState.AddModelError("error", "Lỗi trong quá trình ghi dữ liệu");
                return View();
            }


        }
        public ActionResult Details(string ma_phongban)
        {
            db = new CECMSDbContext();
            var model = db.tblPhongBans.Find(ma_phongban);
            return PartialView(model);
        }
        public ActionResult Delete(string id)
        {
            try
            {
                db = new CECMSDbContext();
                var item = db.tblPhongBans.Where(x => x.MA_PHONGBAN == id).FirstOrDefault();
                if (item != null)
                {
                    db.tblPhongBans.Remove(item);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "PhongBan");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

        }
    }
}