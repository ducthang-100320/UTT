using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThuVienTruongHoc.Areas.Admin.Models;

namespace ThuVienTruongHoc.Areas.Admin.Controllers
{
    public class DocGiaController : Controller
    {
        TRUONGHOCDbContext db;
        // GET: Admin/DocGia
        public ActionResult Index()
        {
            db = new TRUONGHOCDbContext();
            var sinhvien = db.tblSinhViens.Where(x => x.TINH_TRANG == 1).ToList();

            var giangvien = db.tblNhanViens.Where(x => x.MA_CHUCVU.Contains("CV001") ).ToList();

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

            return View(list);
        }
    }
}