using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class MuonDocController : Controller
    {
        // GET: AdminThuVien/MuonDoc
        CECMSDbContext db;
        public ActionResult IndexMuonTra()
        {
            db = new CECMSDbContext();
            var model = db.tblMuonTras.Where(x => x.TRANG_THAI == 1).ToList();

            var sach = db.tblSaches.Where(x => x.TRANG_THAI == 1);
            Session["sach"] = sach;
            return View(model);
        }
        public ActionResult Index(int id)
        {
            db = new CECMSDbContext();
            var model = db.tblSaches.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Sach = model;
            setControl();
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblMuonTra model, int id)
        {
            setControl();
            db = new CECMSDbContext();
            #region getDocGia

            var sinhvien = db.tblSinhViens.Where(x => x.TINH_TRANG == 1).ToList();

            var giangvien = db.tblNhanViens.Where(x => x.MA_CHUCVU.Contains("CV001")).ToList();

            var loai = db.tblLoaiDocGias.Where(x => x.TRANG_THAI == 1);
            Session["loai"] = loai;
            List<tblDocGia> list = new List<tblDocGia>();

            foreach (var item in sinhvien)
            {
                tblDocGia docGia = new tblDocGia();
                docGia.MA_DOCGIA = item.MA_SINHVIEN;
                docGia.MA_LOAI = "SV";
                docGia.MA_THE = item.MA_SINHVIEN;
                docGia.NGAY_SINH = item.NGAY_SINH;
                docGia.SO_DTHOAI = item.SO_DTHOAI;
                docGia.TEN_DOCGIA = item.HO_TEN;
                docGia.TRANG_THAI = 1;
                docGia.GIOI_TINH = item.GIOI_TINH;
                docGia.GHI_CHU = item.GHI_CHU;
                list.Add(docGia);
            }

            foreach (var item1 in giangvien)
            {
                tblDocGia docGia2 = new tblDocGia();
                docGia2.MA_DOCGIA = item1.MA_NHANVIEN;
                docGia2.MA_LOAI = "GV";
                docGia2.MA_THE = item1.MA_NHANVIEN;
                docGia2.NGAY_SINH = item1.NGAY_SINH;
                docGia2.GIOI_TINH = item1.GIOI_TINH;
                docGia2.TEN_DOCGIA = item1.HO_TEN;
                docGia2.SO_DTHOAI = item1.SO_DIENTHOAI;
                docGia2.TRANG_THAI = 1;
                docGia2.GHI_CHU = item1.GHI_CHU;
                list.Add(docGia2);
            }
            #endregion
            var sach = db.tblSaches.Where(x => x.ID == id).FirstOrDefault();
            var muontra = db.tblMuonTras.Where(x => x.MA_DOCGIA == model.MA_DOCGIA && x.TRANG_THAI == 1).ToList();
            //var docgia = (from a in tblAccount 
            //              join b in tblDocGia)
            ViewBag.Sach = sach;
            bool check = false;
            foreach (var item in list)
            {
                if (model.MA_DOCGIA.Equals(item.MA_DOCGIA))
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }

            }
            if (check == false)
            {
                ModelState.AddModelError("", "Mã đọc giả không tồn tại");
                return View();
            }

            foreach (var item in muontra)
            {
                if (item.GHI_CHU.Equals("Quá hạn"))
                {
                    ModelState.AddModelError("", "Mã đọc giả đã quá hạn");
                    return View();
                }

            }
            if (model.SO_LUONG > sach.SO_LUONG)
            {
                ModelState.AddModelError("", "Số lượng sách không đủ");
                return View();
            }
            else
            {
                sach.SO_LUONG = sach.SO_LUONG - model.SO_LUONG;
            }
            if (model.NGAY_MUON.CompareTo(model.NGAY_TRA) == 1 || model.NGAY_MUON.CompareTo(model.NGAY_TRA) == 1)
            {
                ModelState.AddModelError("", "Ngày trả phải lớn hơn ngày mượn");
                return View();
            }

            model.MA_SACH = sach.MA_SACH;
            model.TRANG_THAI = 1;
            model.GHI_CHU = "Đặt trước";

            db.tblMuonTras.Add(model);
            var result = db.SaveChanges();
            return RedirectToAction("IndexMuonTra", "MuonDoc");

        }

        public ActionResult Create()
        {
            db = new CECMSDbContext();

            return View();
        }

        [HttpPost]
        public ActionResult Create(tblMuonTra model, FormCollection collection)
        {
            db = new CECMSDbContext();
            #region getDocGia

            var sinhvien = db.tblSinhViens.Where(x => x.TINH_TRANG == 1).ToList();

            var giangvien = db.tblNhanViens.Where(x => x.MA_CHUCVU.Contains("CV001")).ToList();

            var loai = db.tblLoaiDocGias.Where(x => x.TRANG_THAI == 1);
            Session["loai"] = loai;
            List<tblDocGia> list = new List<tblDocGia>();

            foreach (var item in sinhvien)
            {
                tblDocGia docGia = new tblDocGia();
                docGia.MA_DOCGIA = item.MA_SINHVIEN;
                docGia.MA_LOAI = "SV";
                docGia.MA_THE = item.MA_SINHVIEN;
                docGia.NGAY_SINH = item.NGAY_SINH;
                docGia.SO_DTHOAI = item.SO_DTHOAI;
                docGia.TEN_DOCGIA = item.HO_TEN;
                docGia.TRANG_THAI = 1;
                docGia.GIOI_TINH = item.GIOI_TINH;
                docGia.GHI_CHU = item.GHI_CHU;
                list.Add(docGia);
            }

            foreach (var item1 in giangvien)
            {
                tblDocGia docGia2 = new tblDocGia();
                docGia2.MA_DOCGIA = item1.MA_NHANVIEN;
                docGia2.MA_LOAI = "GV";
                docGia2.MA_THE = item1.MA_NHANVIEN;
                docGia2.NGAY_SINH = item1.NGAY_SINH;
                docGia2.GIOI_TINH = item1.GIOI_TINH;
                docGia2.TEN_DOCGIA = item1.HO_TEN;
                docGia2.SO_DTHOAI = item1.SO_DIENTHOAI;
                docGia2.TRANG_THAI = 1;
                docGia2.GHI_CHU = item1.GHI_CHU;
                list.Add(docGia2);
            }
            #endregion
            var sach = db.tblSaches.Where(x => x.MA_SACH == model.MA_SACH && x.SO_LUONG > 0 && x.TRANG_THAI == 1).FirstOrDefault();
            var muontra = db.tblMuonTras.Where(x => x.MA_DOCGIA == model.MA_DOCGIA && x.TRANG_THAI == 1).ToList();
            //var docgia = (from a in tblAccount 
            //              join b in tblDocGia)
            bool check = false;
            foreach (var item in list)
            {
                if (model.MA_DOCGIA.Equals(item.MA_DOCGIA))
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }

            }

            if (check == false)
            {
                ModelState.AddModelError("", "Mã đọc giả không tồn tại");
                return View();
            }

            if (sach == null)
            {
                ModelState.AddModelError("", "Mã sách này đã hết");
                return View();
            }

            foreach (var item in muontra)
            {
                if (item.GHI_CHU.Equals("Quá hạn"))
                {
                    ModelState.AddModelError("", "Mã đọc giả đã quá hạn");
                    return View();
                }

            }
            if (model.SO_LUONG > sach.SO_LUONG)
            {
                ModelState.AddModelError("", "Số lượng sách không đủ");
                return View();
            }
            else
            {
                sach.SO_LUONG = sach.SO_LUONG - model.SO_LUONG;
            }
            if (model.NGAY_MUON.CompareTo(model.NGAY_TRA) == 1 || model.NGAY_MUON.CompareTo(model.NGAY_TRA) == 1)
            {
                ModelState.AddModelError("", "Ngày trả phải lớn hơn ngày mượn");
                return View();
            }

            model.MA_SACH = sach.MA_SACH;
            model.TRANG_THAI = 1;
            model.GHI_CHU = collection["customRadio"].ToString();
            db.tblMuonTras.Add(model);
            var result = db.SaveChanges();
            return RedirectToAction("IndexMuonTra", "MuonDoc");

        }

        public void setControl()
        {
            db = new CECMSDbContext();

            var cboTheLoai = db.tblTheLoaiSaches.Where(x => x.TRANG_THAI == 1).ToList();
            ViewBag.setcontrolTLoai = cboTheLoai;

            var cboTacGia = db.tblTacGias.Where(x => x.TRANG_THAI == 1).ToList();
            ViewBag.setcontrolTGia = cboTacGia;

            var cboNXB = db.tblNhaXuatBans.Where(x => x.TRANGTHAI == 1).ToList();
            ViewBag.setcontrolNXB = cboNXB;


        }

    }
}
