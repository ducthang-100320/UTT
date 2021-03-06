using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienTruongHoc.Areas.Admin.Models;

namespace ThuVienTruongHoc.Areas.Admin.Controllers
{
    public class BookController : Controller
    {
        TRUONGHOCDbContext db;
        // GET: Admin/Book
        public ActionResult Index(string searchString)
        {
 
            db = new TRUONGHOCDbContext();
            var listTheLoai = db.tblTheLoaiSaches.Where(x => x.TRANG_THAI == 1);
            Session["TheloaiSach"] = listTheLoai;

            var listNXB = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1);
            Session["NXB"] = listNXB;

            var listTacGia = db.tblTacGias.Where(x => x.TRANG_THAI == 1);
            Session["TacGia"] = listTacGia;

            if (!string.IsNullOrEmpty(searchString))
            {
                foreach (var item in listTacGia)
                {
                    if (item.TEN_TACGIA.Contains(searchString))
                    {
                        var model1 = db.tblSaches.Where(x => x.TRANG_THAI == 1 && (x.MA_TACGIA == item.MA_TACGIA)).ToList();
                        return View(model1);
                    }
                }
                foreach (var item1 in listTheLoai)
                {
                    if (item1.TEN_THELOAI.Contains(searchString))
                    {
                        var model1 = db.tblSaches.Where(x => x.TRANG_THAI == 1 && (x.MA_THELOAI == item1.MA_THELOAI)).ToList();
                        return View(model1);
                    }
                }
                var model2 = db.tblSaches.Where(x => x.TRANG_THAI == 1 &&( x.TEN_SACH.Contains(searchString))).ToList();
                return View(model2);
            }
            else
            {
                var model2 = db.tblSaches.Where(x => x.TRANG_THAI == 1).ToList();
                return View(model2);
            }
        
        }
        public ActionResult IndexUser(int page = 1, int pageSize = 5)
        {

            db = new TRUONGHOCDbContext();
            double totalRecord = db.tblSaches.Where(x => x.TRANG_THAI == 1).Count();
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;
            int maxPage = 5;
            double totalPage = 0;
            totalPage = (double)Math.Ceiling(((decimal)(totalRecord / pageSize)));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            var model = db.tblSaches.Where(x => x.TRANG_THAI == 1).OrderByDescending(x => x.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            
            setControl();
            return View();
        }

        [HttpPost]

        public ActionResult Create(tblSach model,HttpPostedFile filePost ,FormCollection collection)
        {
                setControl();
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
            model.MA_NXB = collection["cboNXB"].ToString();
                model.MA_TACGIA = collection["cboTacGia"].ToString();
                model.MA_THELOAI = collection["cboTLoai"].ToString();
                model.MO_TA = "1";
                model.TRANG_THAI = 1;
            int iContent = fileLocation.IndexOf("Content");
            if (iContent > 0)
            {
                model.IMAGE = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
            }
            db = new TRUONGHOCDbContext();
                var item = db.tblSaches.Where(x => x.TRANG_THAI == 1).ToList();
                var result = false;
                foreach (var itemSach in item)
                {
                    if (model.MA_SACH == itemSach.MA_SACH)
                    {
                        result = false;
                        break;
                    }
                    else
                    {
                        result = true;
                    }
                }
                if (result == false)
                {
                    ModelState.AddModelError("", "Mã sách đã tồn tại");
                    setControl();
                    return View();
                }
                else if (collection["cboNXB"].ToString() == "-1"|| collection["cboTacGia"].ToString() == "-1" || collection["cboTLoai"].ToString() == "-1" || model.MA_SACH == null)
                {
                    ModelState.AddModelError("", "Lỗi kiểm tra dữ liệu");
                    setControl();
                    return View();
                }
                else
                {
                    db.tblSaches.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Book");
                }
            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            db = new TRUONGHOCDbContext();
            setControl();
            var model = db.tblSaches.Find(id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblSach model,HttpPostedFile filePost ,FormCollection collection)
        {
            setControl();
            var itemS = db.tblSaches.Find(model.ID);
            var item = db.tblSaches.Where(x => x.TRANG_THAI == 1 && x.ID != model.ID).ToList();
        
            itemS.MA_SACH = model.MA_SACH;
            itemS.TEN_SACH = model.TEN_SACH;
            itemS.MA_NXB = collection["cboNXB"].ToString();
            itemS.MA_THELOAI = collection["cboTLoai"].ToString();
            itemS.MA_TACGIA = collection["cboTacGia"].ToString();
            itemS.SO_LUONG = model.SO_LUONG;
            string fileLocation = "";
            if (Request.Files["filePost"].ContentLength <= 0) { itemS.IMAGE = model.IMAGE; }
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
                itemS.IMAGE = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
            }
            var result = false;
            foreach (var itemSach in item)
            {
                if (model.MA_SACH == itemSach.MA_SACH)
                {
                    result = false;
                    break;
                }
                else
                {
                    result = true;
                }
            }
            if (result == false)
            {
                ModelState.AddModelError("", "Mã sách đã tồn tại");
                setControl();
                return View(model);
            }
            else if (collection["cboNXB"].ToString() == "-1" || collection["cboTacGia"].ToString() == "-1" || collection["cboTLoai"].ToString() == "-1" || model.MA_SACH == null)
            {
                ModelState.AddModelError("", "Lỗi kiểm tra dữ liệu");
                setControl();
                return View();
            }
            else
            {
                db.SaveChanges();
                return RedirectToAction("Index", "Book");
            }
            
        }
        public void setControl()
        {
            db = new TRUONGHOCDbContext();

            var cboTheLoai = db.tblTheLoaiSaches.Where(x => x.TRANG_THAI == 1).ToList();
            ViewBag.setcontrolTLoai = cboTheLoai;

            var cboTacGia = db.tblTacGias.Where(x => x.TRANG_THAI == 1).ToList();
            ViewBag.setcontrolTGia = cboTacGia;

            var cboNXB = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1).ToList();
            ViewBag.setcontrolNXB = cboNXB;


        }

        public ActionResult Details(int id)
        {
            setControl();
            db = new TRUONGHOCDbContext();
            var model = db.tblSaches.Find(id);
            return PartialView(model);
        }
    }
}