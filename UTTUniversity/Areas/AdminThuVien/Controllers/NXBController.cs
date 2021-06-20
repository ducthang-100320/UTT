using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class NXBController : Controller
    {
        // GET: AdminThuVien/NXB
        CECMSDbContext db;
        // GET: Admin/NXB
        public ActionResult Index()
        {
            db = new CECMSDbContext();
            var model = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            db = new CECMSDbContext();
            int STT = db.tblNhaXuatBans.Count();
            STT++;
            var model = new tblNhaXuatBan();
            model.MA_NXB = "NXB00"+STT;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(tblNhaXuatBan model, FormCollection collection)
        {
            db = new CECMSDbContext();
            int STT = db.tblNhaXuatBans.Count();
            STT++;
            model.MA_NXB = "NXB00" + STT;
            model.TRANGTHAI = 1;
            var item = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1).ToList();
            //foreach (var itemNXB in item)
            //{
            //    if (model.MA_NXB == itemNXB.MA_NXB)
            //    {
            //        ModelState.AddModelError("", "Mã đã tồn tại");
            //        break;
            //    }

            //}

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
        public ActionResult Details(string id)
        {
            db = new CECMSDbContext();
            var model = db.tblNhaXuatBans.Where(x => x.MA_NXB == id).FirstOrDefault();
           
            return PartialView(model);
        }

        public ActionResult Edit(string id)
        {

            db = new CECMSDbContext();
            var model = db.tblNhaXuatBans.Where(x => x.MA_NXB == id).FirstOrDefault();
            Session["Ma_Trung"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblNhaXuatBan model, FormCollection collection)
        {
            db = new CECMSDbContext();
            var NXB = Session["Ma_Trung"] as UTTUniversity.Models.tblNhaXuatBan;
            var item = db.tblNhaXuatBans.Find(NXB.MA_NXB);

            item.TEN_NXB = model.TEN_NXB;
            item.MA_NXB = NXB.MA_NXB;
            item.DIA_CHI = model.DIA_CHI;
            item.GHI_CHU = model.GHI_CHU;
            item.SO_DTHOAI = model.SO_DTHOAI;

            //var itemnxb = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1 && x.MA_NXB != model.MA_NXB).ToList();
            //foreach (var itemNXB in itemnxb)
            //{
            //    if (item.MA_NXB == itemNXB.MA_NXB)
            //    {
            //        ModelState.AddModelError("", "Mã đã tồn tại");
            //        break;
            //    }

            //}

            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("Index", "NXB");
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult Delete(string id)
        {
            db = new CECMSDbContext();
            var item = db.tblNhaXuatBans.Where(x => x.MA_NXB == id).FirstOrDefault();
            if (item != null)
            {
                item.TRANGTHAI = 0;
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