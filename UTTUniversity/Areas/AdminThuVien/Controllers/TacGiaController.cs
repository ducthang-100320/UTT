using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienTruongHoc.Areas.Admin.Models;

namespace ThuVienTruongHoc.Areas.Admin.Controllers
{
    public class TacGiaController : Controller
    {
        TRUONGHOCDbContext db;
        // GET: Admin/TacGia
        public ActionResult Index()
        {
            db = new TRUONGHOCDbContext();
            var model = db.tblTacGias.Where(x => x.TRANG_THAI == 1).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblTacGia model, HttpPostedFile filePost,FormCollection collection)
        {
            string fileLocation = "";
            if (Request.Files["filePost"].ContentLength <= 0) { model.IMAGE = ""; }
            ModelState["filePost"].Errors.Clear();

            //if (ModelState.IsValid == true)
            //{
            if (Request.Files["filePost"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["filePost"].FileName);
                fileLocation = Server.MapPath("~/Content/") + Request.Files["filePost"].FileName;
                if (System.IO.File.Exists(fileLocation))
                {
                    System.IO.File.Delete(fileLocation);
                }
                Request.Files["filePost"].SaveAs(fileLocation);
            }
            string strRadio = collection["customRadio"].ToString();
            if (strRadio == "Nam")
            {
                model.GIOI_TINH = 1;
            }
            else if(strRadio =="Nu")
            {
                model.GIOI_TINH = 0;
            }
            db = new TRUONGHOCDbContext();
            model.TRANG_THAI = 1;
            int iContent = fileLocation.IndexOf("Content");
            if (iContent > 0)
            {
                model.IMAGE = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
            }
            var item = db.tblTacGias.Where(x => x.TRANG_THAI == 1).ToList();
            foreach (var itemTG in item)
            {
                if (model.MA_TACGIA == itemTG.MA_TACGIA)
                {
                    ModelState.AddModelError("", "Mã đã tồn tại");
                    break;
                }

            }

            if (ModelState.IsValid)
            {

                db.tblTacGias.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index", "TacGia");
            }
            else
            {
                return View();
            }


        }
        public ActionResult Details(int id)
        {
            db = new TRUONGHOCDbContext();
            var model = db.tblTacGias.Find(id);
            return PartialView(model);
        }

        public ActionResult Edit(int id)
        {

            db = new TRUONGHOCDbContext();
            var model = db.tblTacGias.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblTacGia model, HttpPostedFile filePost, FormCollection collection )
        {
            db = new TRUONGHOCDbContext();
            var item = db.tblTacGias.Find(model.ID);
            item.TEN_TACGIA = model.TEN_TACGIA;
            item.MA_TACGIA = model.MA_TACGIA;
            item.MO_TA = model.MO_TA;
            item.NGAY_SINH = model.NGAY_SINH;
            string fileLocation = "";
            if (Request.Files["filePost"].ContentLength <= 0) { item.IMAGE = model.IMAGE; }
            ModelState["filePost"].Errors.Clear();

            //if (ModelState.IsValid == true)
            //{
            if (Request.Files["filePost"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["filePost"].FileName);
                fileLocation = Server.MapPath("~/Content/") + Request.Files["filePost"].FileName;
                if (System.IO.File.Exists(fileLocation))
                {
                    System.IO.File.Delete(fileLocation);
                }
                Request.Files["filePost"].SaveAs(fileLocation);
            }
            int iContent = fileLocation.IndexOf("Content");
            if (iContent > 0)
            {
                item.IMAGE = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
            }
            string strRadio = collection["customRadio"].ToString();
            if (strRadio == "Nam")
            {
                item.GIOI_TINH = 1;
            }
            else if (strRadio == "Nu")
            {
                item.GIOI_TINH = 0;
            }

            var itemnxb = db.tblTacGias.Where(x => x.TRANG_THAI == 1 && x.ID != model.ID).ToList();
            foreach (var itemTG in itemnxb)
            {
                if (item.MA_TACGIA == itemTG.MA_TACGIA)
                {
                    ModelState.AddModelError("", "Mã đã tồn tại");
                    break;
                }

            }

            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("Index", "TacGia");
            }
            else
            {
                return View(model);
            }

        }

        public ActionResult Delete(int id)
        {
            db = new TRUONGHOCDbContext();
            var item = db.tblTacGias.Find(id);
            if (item != null)
            {
                db.tblTacGias.Remove(item);
                db.SaveChanges();
                return RedirectToAction("Index", "TacGia");
            }
            else
            {
                return View();
            }

        }
    }
}