using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class NhapSachController : Controller
    {
        CECMSDbContext db;
        // GET: AdminThuVien/NhapSach
        public ActionResult Index()
        {
            db = new CECMSDbContext();
            var model1 = db.tblNhanViens.Where(x => x.TRANGTHAI == 1).ToList();
            ViewBag.nhanvien = model1;
            var model = db.tblPhieuNhapSaches.Where(x => x.TRANG_THAI == 1).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            db = new CECMSDbContext();
            var listNXB = db.tblNhaXuatBans.Where(x => x.TRANGTHAI >= 1).ToList();
            ViewBag.setcontrolNXB = listNXB;
            int STT = db.tblPhieuNhapSaches.Count();
            STT++;
            var item = Session["user"] as UTTUniversity.Models.tblNhanVien;
            var model = new tblPhieuNhapSach();
            model.MA_PHIEU = "MP00" + STT;
            model.MA_NHANVIEN = item.MA_NHANVIEN;
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(tblPhieuNhapSach model, FormCollection collection)
        {
            db = new CECMSDbContext();
            int STT = db.tblPhieuNhapSaches.Count();
            STT++;
            var item = Session["user"] as UTTUniversity.Models.tblNhanVien;
            model.MA_PHIEU = "NS00" + STT;
            model.MA_NHANVIEN = item.MA_NHANVIEN;
            model.MA_NXB = collection["cboNXB"].ToString();
            model.TRANG_THAI = 1;

            if (ModelState.IsValid)
            {
                db.tblPhieuNhapSaches.Add(model);
                db.SaveChanges();
                return RedirectToAction("ChiTietPhieuNhap","NhapSach",new {id = model.MA_PHIEU });
            }
            else
            {
                return View();
            }
           
        }
        public ActionResult ChiTietPhieuNhap(string id)
        {
            db = new CECMSDbContext();
            var model = new tblChiTietPhieuNhap();
            model.MA_PHIEUNHAP = id;
            var model1 = db.tblChiTietPhieuNhaps.Where(x => x.TRANG_THAI == 1 && x.MA_PHIEUNHAP.Equals(id)).ToList();
            ViewBag.chitietphieu = model1;
            var model2 = db.tblPhieuNhapSaches.Where(x => x.MA_PHIEU.Equals(id)).FirstOrDefault();
            Session["PhieuNhap"] = model2;
            return View(model);
        }
        [HttpPost]
        public ActionResult ChiTietPhieuNhap(tblChiTietPhieuNhap model , FormCollection collection)
        {
            db = new CECMSDbContext();
            var phieu = Session["PhieuNhap"] as UTTUniversity.Models.tblPhieuNhapSach;
            model.MA_PHIEUNHAP = phieu.MA_PHIEU;
            model.THANH_TIEN = model.SO_LUONG * model.DON_GIA;
            model.TRANG_THAI = 1;
            model.GHI_CHU = "";

            db.tblChiTietPhieuNhaps.Add(model);
            db.SaveChanges();
            return RedirectToAction("ChiTietPhieuNhap", "NhapSach",new { id = model.MA_PHIEUNHAP });
        }

        public ActionResult Edit(string id)
        {
            db = new CECMSDbContext();
            var model = db.tblPhieuNhapSaches.Find(id);
            Session["Ma_Trung"] = model;
            var listNXB = db.tblNhaXuatBans.Where(x => x.TRANGTHAI >= 1).ToList();
            ViewBag.setcontrolNXB = listNXB;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblPhieuNhapSach model, FormCollection collection)
        {
            db = new CECMSDbContext();
            var phieu = Session["Ma_Trung"] as UTTUniversity.Models.tblPhieuNhapSach;
            var item = db.tblPhieuNhapSaches.Where(x => x.MA_PHIEU.Equals(phieu.MA_PHIEU)).FirstOrDefault();
            var item1 = Session["user"] as UTTUniversity.Models.tblNhanVien;
            item.MA_NHANVIEN = item1.MA_NHANVIEN;
            item.MA_PHIEU = phieu.MA_PHIEU;
            item.NGAY_NHAP = model.NGAY_NHAP;
            item.MA_NXB = collection["cboNXB"].ToString();
            db.SaveChanges();
            return RedirectToAction("Index", "NhapSach");
        }
        
        public ActionResult EditChiTietPhieuNhap(int id)
        {
            db = new CECMSDbContext();
            var model = db.tblChiTietPhieuNhaps.Where(x => x.ID == id).FirstOrDefault();
            Session["Ma_Trung"] = model;
            return View(model);
        }
        [HttpPost]
        public ActionResult EditChiTietPhieuNhap(tblChiTietPhieuNhap model , FormCollection collection)
        {
            db = new CECMSDbContext();
            var item = Session["Ma_Trung"] as UTTUniversity.Models.tblChiTietPhieuNhap;
            var model1 = db.tblChiTietPhieuNhaps.Where(x => x.ID == item.ID).FirstOrDefault();
            model1.MA_PHIEUNHAP = item.MA_PHIEUNHAP;
            model1.SO_LUONG = model.SO_LUONG;
            model1.TEN_SACH = model.TEN_SACH;
            model1.TEN_THELOAI = model.TEN_THELOAI;
            model1.DON_GIA = model.DON_GIA;
            model1.GHI_CHU = model.GHI_CHU;
            model1.THANH_TIEN = model.SO_LUONG * model.DON_GIA;
            db.SaveChanges();
            return RedirectToAction("ChiTietPhieuNhap","NhapSach",new { id = model1.MA_PHIEUNHAP });
        }

        public ActionResult DeletePhieuNhap(string id)
        {
            return View();
        }
    }
}