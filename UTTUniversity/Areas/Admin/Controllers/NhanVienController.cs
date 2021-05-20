using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        #region MyRegion
        CECMSDbContext db;
        #endregion
        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = "Người dùng";
            CECMSDbContext db = new CECMSDbContext();
            var model = (from a in db.tblAccounts
                         join b in db.tblNhanViens

                         on a.ID equals b.Account_ID

                         select new
                         {
                             objAccount = a,
                             objNhanVien = b
                         }
                        ).ToList();
            List<tblAccountNhanVien> lstAU = new List<tblAccountNhanVien>();
            foreach (var item in model)
            {
                tblAccountNhanVien anv = new tblAccountNhanVien();

                anv.AccoutName = item.objAccount.AccoutName;
                anv.Account_ID = item.objAccount.ID;
                anv.DIA_CHI = item.objNhanVien.DIA_CHI;
                anv.NGAY_SINH = item.objNhanVien.NGAY_SINH;
                anv.CreatedDate = item.objAccount.CreatedDate;
                anv.CreatedUser = item.objAccount.CreatedUser;
                anv.DateIssued = item.objAccount.DateIssued;
                anv.QUE_QUAN = item.objNhanVien.QUE_QUAN;
                anv.GHI_CHU = item.objNhanVien.GHI_CHU;
                anv.Email = item.objNhanVien.Email;
                anv.SO_DIENTHOAI = item.objNhanVien.SO_DIENTHOAI;
                anv.MA_PHONGBAN = item.objNhanVien.MA_PHONGBAN;
                anv.MA_CHUCVU = item.objNhanVien.MA_CHUCVU;
                anv.MA_NHANVIEN = item.objNhanVien.MA_NHANVIEN;
                anv.MA_TRINHDO = item.objNhanVien.MA_TRINHDO;
                anv.ModifiedDate = item.objAccount.ModifiedDate;
                anv.ModifiedUser = item.objAccount.ModifiedUser;
                anv.Password = item.objAccount.Password;
                anv.GIOI_TINH = item.objNhanVien.GIOI_TINH;
                anv.HO_TEN = item.objNhanVien.HO_TEN;
                anv.Image = item.objNhanVien.Image;
                anv.ImageUrl = item.objNhanVien.ImageUrl;
                anv.ID = item.objNhanVien.ID;
                lstAU.Add(anv);
            }
            return View(lstAU);
        }
    }
}