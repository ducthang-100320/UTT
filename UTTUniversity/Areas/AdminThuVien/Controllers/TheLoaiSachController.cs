using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class TheLoaiSachController : Controller
    {
        // GET: AdminThuVien/TheLoaiSach
        CECMSDbContext db;
        // GET: Admin/TheLoaiSach
        public ActionResult Index()
        {
            db = new CECMSDbContext();
            var model = db.tblTheLoaiSaches.Where(x => x.TRANG_THAI == 1).ToList();
            return View(model);

        }

        public ActionResult Create()
        {
            db = new CECMSDbContext();
            int STT  = db.tblTheLoaiSaches.Count();
            STT++;
            var model = new tblTheLoaiSach();
            model.MA_THELOAI = "TL00" + STT;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(tblTheLoaiSach model, FormCollection collection)
        {
            db = new CECMSDbContext();
            int STT = db.tblTheLoaiSaches.Count();
            STT++;
            model.MA_THELOAI = "TL00" + STT;
            model.TRANG_THAI = 1;
            var item = db.tblTheLoaiSaches.Where(x => x.TRANG_THAI == 1).ToList();
            foreach (var itemNXB in item)
            {
                if (model.MA_THELOAI == itemNXB.MA_THELOAI)
                {
                    ModelState.AddModelError("", "Mã đã tồn tại");
                    break;
                }

            }

            if (ModelState.IsValid)
            {

                db.tblTheLoaiSaches.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "TheLoaiSach");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Details(string id)
        {
            db = new CECMSDbContext();
            var model = db.tblTheLoaiSaches.Where(x => x.MA_THELOAI == id).FirstOrDefault();
            return PartialView(model);
        }

        public ActionResult Edit(string id)
        {

            db = new CECMSDbContext();
            var model = db.tblTheLoaiSaches.Where(x => x.MA_THELOAI == id).FirstOrDefault();
            Session["Ma_Trung"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblTheLoaiSach model, FormCollection collection)
        {
            db = new CECMSDbContext();
            var item = db.tblTheLoaiSaches.Find(model.MA_THELOAI);
            var Tloai = Session["Ma_Trung"] as UTTUniversity.Models.tblTheLoaiSach;
            item.TEN_THELOAI = model.TEN_THELOAI;
            item.MA_THELOAI = Tloai.MA_THELOAI;


            //var itemtl = db.tblTheLoaiSaches.Where(x => x.TRANG_THAI == 1 && x.MA_THELOAI != model.MA_THELOAI).ToList();
            //foreach (var itemNXB in itemtl)
            //{
            //    if (item.MA_THELOAI == itemNXB.MA_THELOAI)
            //    {
            //        ModelState.AddModelError("", "Mã đã tồn tại");
            //        break;
            //    }

            //}

            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("Index", "TheLoaiSach");
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult Delete(string id)
        {
            db = new CECMSDbContext();
            var item = db.tblTheLoaiSaches.Where(x => x.MA_THELOAI == id).FirstOrDefault();
            if (item != null)
            {
                item.TRANG_THAI = 0;
                db.SaveChanges();
                return RedirectToAction("Index", "TheLoaiSach");
            }
            else
            {
                return View();
            }

        }
    }
}