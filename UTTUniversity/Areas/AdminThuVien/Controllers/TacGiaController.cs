using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class TacGiaController : Controller
    {
        // GET: AdminThuVien/TacGia
        CECMSDbContext db;
        // GET: Admin/TacGia
        public ActionResult Index()
        {
            db = new CECMSDbContext();
            var model = db.tblTacGias.Where(x => x.TRANG_THAI == 1).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            db = new CECMSDbContext();
            int STT = db.tblTacGias.Count();
            STT++;
            var model = new tblTacGia();
            model.MA_TACGIA = "TG00" + STT;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(tblTacGia model, HttpPostedFile filePost, FormCollection collection)
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
            else if (strRadio == "Nu")
            {
                model.GIOI_TINH = 0;
            }
            db = new CECMSDbContext();
            int STT = db.tblTacGias.Count();
            STT++;
            model.MA_TACGIA = "TG00" + STT;
            model.TRANG_THAI = 1;
            int iContent = fileLocation.IndexOf("Content");
            if (iContent > 0)
            {
                model.IMAGE = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
            }
            //var item = db.tblTacGias.Where(x => x.TRANG_THAI == 1).ToList();
            //foreach (var itemTG in item)
            //{
            //    if (model.MA_TACGIA == itemTG.MA_TACGIA)
            //    {
            //        ModelState.AddModelError("", "Mã đã tồn tại");
            //        break;
            //    }

            //}

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
        public ActionResult Details(string id)
        {
            db = new CECMSDbContext();
            var model = db.tblTacGias.Where(x=>x.MA_TACGIA == id ).FirstOrDefault();
            return PartialView(model);
        }

        public ActionResult Edit(string id)
        {

            db = new CECMSDbContext();
            var model = db.tblTacGias.Find(id);
            Session["Ma_Trung"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblTacGia model, HttpPostedFile filePost, FormCollection collection)
        {
            db = new CECMSDbContext();
            var TG = Session["Ma_Trung"] as UTTUniversity.Models.tblTacGia;
            var item = db.tblTacGias.Find(TG.MA_TACGIA);
            item.TEN_TACGIA = model.TEN_TACGIA;
            item.MA_TACGIA = TG.MA_TACGIA;
            item.MO_TA = model.MO_TA;
            item.NGAYSINH = model.NGAYSINH;
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

            //var itemnxb = db.tblTacGias.Where(x => x.TRANG_THAI == 1 && x.MA_TACGIA != model.MA_TACGIA).ToList();
            //foreach (var itemTG in itemnxb)
            //{
            //    if (item.MA_TACGIA == itemTG.MA_TACGIA)
            //    {
            //        ModelState.AddModelError("", "Mã đã tồn tại");
            //        break;
            //    }

            //}

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

        public ActionResult Delete(string id)
        {
            db = new CECMSDbContext();
            var item = db.tblTacGias.Where(x => x.MA_TACGIA == id).FirstOrDefault();
            if (item != null)
            {
                item.TRANG_THAI = 0;
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