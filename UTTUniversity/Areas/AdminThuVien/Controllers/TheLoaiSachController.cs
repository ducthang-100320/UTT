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
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblTheLoaiSach model, FormCollection collection)
        {
            db = new CECMSDbContext();
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

        public ActionResult Details(int id)
        {
            db = new CECMSDbContext();
            var model = db.tblTheLoaiSaches.Find(id);
            return PartialView(model);
        }

        public ActionResult Edit(int id)
        {

            db = new CECMSDbContext();
            var model = db.tblTheLoaiSaches.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblTheLoaiSach model, FormCollection collection)
        {
            db = new CECMSDbContext();
            var item = db.tblTheLoaiSaches.Find(model.ID);

            item.TEN_THELOAI = model.TEN_THELOAI;
            item.MA_THELOAI = model.MA_THELOAI;


            var itemtl = db.tblTheLoaiSaches.Where(x => x.TRANG_THAI == 1 && x.ID != model.ID).ToList();
            foreach (var itemNXB in itemtl)
            {
                if (item.MA_THELOAI == itemNXB.MA_THELOAI)
                {
                    ModelState.AddModelError("", "Mã đã tồn tại");
                    break;
                }

            }

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

        public ActionResult Delete(int id)
        {
            db = new CECMSDbContext();
            var item = db.tblTheLoaiSaches.Find(id);
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