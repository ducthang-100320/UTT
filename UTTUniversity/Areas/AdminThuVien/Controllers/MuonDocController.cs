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
            DateTime today = DateTime.Now;
            foreach (var item in model)
            {
                if(today.CompareTo(item.NGAY_TRA) == 1 || today.CompareTo(item.NGAY_TRA) == 0)
                {
                    item.GHI_CHU = item.GHI_CHU;
                }
                else
                {
                    item.GHI_CHU = "Quá hạn";
                    
                }
            }
            db.SaveChanges();
            var sach = db.tblSaches.Where(x => x.TRANG_THAI == 1);
            Session["sach"] = sach;
            return View(model);
        }
        public ActionResult Index(string id)
        {
            db = new CECMSDbContext();
            var model = db.tblSaches.Where(x => x.MA_SACH == id).FirstOrDefault();
            ViewBag.Sach = model;
            setControl();
            return View();
        }
        [HttpPost]
        public ActionResult Index(tblMuonTra model, string id)
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
            var sach = db.tblSaches.Where(x => x.MA_SACH == id).FirstOrDefault();
            var muontra = db.tblMuonTras.Where(x => x.MA_DOCGIA == model.MA_DOCGIA && x.TRANG_THAI == 1).ToList();
            //var docgia = (from a in tblAccount 
            //              join b in tblDocGia)
            ViewBag.Sach = sach;
            bool check = false;
            //foreach (var item in list)
            //{
            //    if (model.MA_DOCGIA.Equals(item.MA_DOCGIA))
            //    {
            //        check = true;
            //        break;
            //    }
            //    else
            //    {
            //        check = false;
            //    }

            //}
            //if (check == false)
            //{
            //    ModelState.AddModelError("", "Mã đọc giả không tồn tại");
            //    return View();
            //}
            var docgia = Session["user"] as UTTUniversity.Models.tblNhanVien;
            model.MA_DOCGIA = docgia.MA_NHANVIEN;
            foreach (var item in muontra)
            {
                if (item.GHI_CHU.Equals("Quá hạn"))
                {
                    ModelState.AddModelError("", "Mã đọc giả đã quá hạn");
                    return View();
                }

            }
            if (model.SO_LUONG > sach.SO_LUONG )
            {
                ModelState.AddModelError("", "Số lượng sách không đủ");
                return View();
            }
            else if(model.SO_LUONG == 0)
            {
                ModelState.AddModelError("", "Số lượng sách phải lớn hơn 0");
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
            if (model.MA_SACH != null && model.MA_DOCGIA !=null)
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
                if (model.NGAY_MUON.CompareTo(model.NGAY_TRA) == 1)
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
            else
            {
                ModelState.AddModelError("", "Yêu cầu nhập đủ thông tin");
                return View();
            }

        }

        public ActionResult Edit(int id)
        {
            db = new CECMSDbContext();
            var model = db.tblMuonTras.Find(id);
           

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblMuonTra model ,FormCollection collection)
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
            var muontra_edit = db.tblMuonTras.Find(model.ID);
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
            if (model.NGAY_MUON.CompareTo(model.NGAY_TRA) == 1)
            {
                ModelState.AddModelError("", "Ngày trả phải lớn hơn ngày mượn");
                return View();
            }
            if (muontra_edit.GHI_CHU.Equals("Đặt trước"))
            {
                sach.SO_LUONG = sach.SO_LUONG ;
                
            }
            else if(muontra_edit.GHI_CHU.Equals("Đang mược") || muontra_edit.GHI_CHU.Equals("Quá hạn"))
            {
                sach.SO_LUONG = sach.SO_LUONG + muontra_edit.SO_LUONG;
            }
            else
            {
                sach.SO_LUONG = sach.SO_LUONG;
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

            if ((collection["customRadio"].ToString().Equals("Đã trả") && muontra_edit.GHI_CHU.Equals("Đang mượn"))||
                (collection["customRadio"].ToString().Equals("Đã trả") && muontra_edit.GHI_CHU.Equals("Quá hạn"))
                )
            {
                sach.SO_LUONG = sach.SO_LUONG +muontra_edit.SO_LUONG ;
                muontra_edit.NGAY_TRA = DateTime.Now;
            }
            else
            {
                sach.SO_LUONG = sach.SO_LUONG ;
                muontra_edit.NGAY_TRA = model.NGAY_TRA;

            }
            muontra_edit.GHI_CHU = collection["customRadio"].ToString();
            muontra_edit.SO_LUONG = model.SO_LUONG;
            muontra_edit.MA_DOCGIA = model.MA_DOCGIA;
            muontra_edit.MA_SACH = model.MA_SACH;
            muontra_edit.NGAY_MUON = model.NGAY_MUON;
            
            db.SaveChanges();

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

        public ActionResult Delete(int id)
        {
            db = new CECMSDbContext();
            var model = db.tblMuonTras.Find(id);
            if (model != null)
            {
                model.TRANG_THAI = 0;
                db.SaveChanges();
                return RedirectToAction("IndexMuonTra", "MuonDoc");
            }
            else
            return View();
        }
    }
}
