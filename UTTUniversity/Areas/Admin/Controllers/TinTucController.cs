using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        #region MyRegion
        CECMSDbContext db = new CECMSDbContext();

        #endregion
        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            db = new CECMSDbContext();
            var Category = db.tblCategories.Where(x => x.Status == 1).ToList();
            Session["Category"] = Category;
            db = new CECMSDbContext();
            var model = db.tblNews.Where(x => x.Status == 1).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            db = new CECMSDbContext();
            var Category = db.tblCategories.Where(x => x.Status == 1).ToList();
            Session["Category"] = Category;
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(tblNew model, FormCollection collection, HttpPostedFile filePost, HttpPostedFile filePost2)
        {
            string fileLocation = "";
            if (Request.Files["filePost"].ContentLength <= 0) { model.ImageLarge = ""; }
            model.ImageLarge = "../assets/images/user_pic.jfif";
            ModelState["filePost"].Errors.Clear();

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
            string fileLocation2 = "";
            if (Request.Files["filePost2"].ContentLength <= 0) { model.ImageThumb = ""; }
            //model.ImageThumb = "../assets/images/user_pic.jfif";
            ModelState["filePost2"].Errors.Clear();
            //if (ModelState.IsValid == true)
            //{
            if (Request.Files["filePost2"].ContentLength > 0)
            {
                string fileExtension2 = System.IO.Path.GetExtension(Request.Files["filePost2"].FileName);
                fileLocation2 = Server.MapPath("~/Content/") + Request.Files["filePost2"].FileName;
                if (System.IO.File.Exists(fileLocation2))
                {
                    System.IO.File.Delete(fileLocation2);
                }
                Request.Files["filePost2"].SaveAs(fileLocation2);

            }


            //var Sex = Collection["customRadio"];
            //if (collection["customRadio"].ToString().Trim() != "")
            //    userItem.Sex = Convert.ToInt32(collection["cboStatus"].ToString());
            //else
            //    userItem.Sex = 0;

            string strRadio = collection["gender"].ToString();

            if (strRadio == "isHot")
            {
                model.IsHot = 1;
                model.IsView = 0;
                model.IsComment = 0;
                model.IsApproval = 0;
            }
            else if (strRadio == "isView")
            {
                model.IsHot = 0;
                model.IsView = 1;
                model.IsComment = 0;
                model.IsApproval = 0;
            }
            else if (strRadio == "isApro")
            {
                model.IsHot = 0;
                model.IsView = 0;
                model.IsComment = 0;
                model.IsApproval = 1;
            }
            model.CateNewsID = Convert.ToInt32(collection["cboCate"].ToString());

            //model.FullDescribe = "1";
            model.Language = 1;
            model.CommentTotal = 100;
            model.CreatedDate = DateTime.Now;
            model.CreatedUser = "ducthang";
            model.ModifiedDate = DateTime.Now;
            model.ModifiedUser = "ducthang";

            model.Status = 1;


            int iContent = fileLocation.IndexOf("Content");
            if (iContent > 0)
            {
                model.ImageLarge = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
            }
            int iContent2 = fileLocation2.IndexOf("Content");
            if (iContent2 > 0)
            {
                model.ImageThumb = @"\" + fileLocation2.Substring(iContent, fileLocation2.Length - iContent2);
            }

            //userItem.ImageUrl = @"\" + fileLocation;


            db.tblNews.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "TinTuc");
        }
        public ActionResult Edit(int id)
        {
            db = new CECMSDbContext();
            var Category = db.tblCategories.Where(x => x.Status == 1).ToList();
            Session["Category"] = Category;
            db = new CECMSDbContext();
            var model = db.tblNews.First(m => m.ID == id);
            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(tblNew model, FormCollection collection, HttpPostedFile filePost, HttpPostedFile filePost2)
        {

            //db = new CECMSDbContext();
            //var Category = db.tblCategories.Where(x => x.Status == 1).ToList();
            //Session["Category"] = Category;

            db = new CECMSDbContext();


            var item = db.tblNews.Find(model.ID);
            item.Author = model.Author;
            item.PostDate = model.PostDate;

            if (collection["cboCate"].ToString().Trim() != "")
                item.CateNewsID = Convert.ToInt32(collection["cboCate"].ToString());
            else
                item.CateNewsID = -1;

            string fileLocation = "";
            if (Request.Files["filePost"].ContentLength <= 0) { model.ImageLarge = ""; }

            if (Request.Files["filePost"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["filePost"].FileName);
                fileLocation = Server.MapPath("~/Content/") + Request.Files["filePost"].FileName;
                //fileLocation = fileLocation.Replace(".xlsx", DateTime.Now + ".xlsx");

                if (System.IO.File.Exists(fileLocation))
                {
                    System.IO.File.Delete(fileLocation);
                }
                Request.Files["filePost"].SaveAs(fileLocation);
                int iContent = fileLocation.IndexOf("Content");
                if (iContent > 0)
                {
                    item.ImageLarge = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
                }
            }
            else
            {
                item.ImageLarge = model.ImageLarge;
            }

            string fileLocation2 = "";
            if (Request.Files["filePost2"].ContentLength <= 0) { model.ImageLarge = ""; }
            if (Request.Files["filePost2"].ContentLength > 0)
            {
                string fileExtension2 = System.IO.Path.GetExtension(Request.Files["filePost2"].FileName);
                fileLocation2 = Server.MapPath("~/Content/") + Request.Files["filePost2"].FileName;
                //fileLocation = fileLocation.Replace(".xlsx", DateTime.Now + ".xlsx");

                if (System.IO.File.Exists(fileLocation2))
                {
                    System.IO.File.Delete(fileLocation2);
                }
                Request.Files["filePost2"].SaveAs(fileLocation2);
                int iContent2 = fileLocation2.IndexOf("Content");
                if (iContent2 > 0)
                {
                    item.ImageThumb = @"\" + fileLocation2.Substring(iContent2, fileLocation2.Length - iContent2);
                }
            }
            else
            {
                item.ImageThumb = model.ImageThumb;
            }

            item.FullDescribe = model.FullDescribe;
            var Result = db.SaveChanges();

            if (Result >= 0)
            {
                ModelState.AddModelError("success", "Cập nhật dữ liệu thành công");
                return RedirectToAction("Index", "TinTuc");
            }
            else
            {
                ModelState.AddModelError("error", "Lỗi trong quá trình ghi dữ liệu");
                return View();
            }


        }
        [ValidateInput(false)]
        public ActionResult Details(int id)
        {
            db = new CECMSDbContext();
            var Category = db.tblCategories.Where(x => x.Status == 1).ToList();
            Session["Category"] = Category;
            db = new CECMSDbContext();
            var model = db.tblNews.Find(id);
            //if (model.IsHot = 1)
            //{
            //        <p> Tin Hot </p>
            //        }
            //else if (model.IsView = 1)
            //{
            //        <p> Tin Mới </p>
            //        }
            //else if (model.IsComment = 1)
            //{
            //        <p> Comment </p>
            //        }
            //else
            //{
            //        <p> Cho phép </p>
            //}

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                db = new CECMSDbContext();
                //var ID = Convert.ToInt32(id);
                var item = db.tblNews.Find(id);
                if (item != null)
                {
                    db.tblNews.Remove(item);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "TinTuc");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}