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
            ViewBag.Breadcrumb = "Nhân Viên";
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
                
                anv.ID = item.objNhanVien.ID;
                lstAU.Add(anv);
            }
            return View(lstAU);
        }
        [HttpGet]
        public ActionResult Create()
        {
            db = new CECMSDbContext();
            var PhongBan = db.tblPhongBans.ToList();
            Session["PhongBan"] = PhongBan;
            var ChucVu = db.tblChucVus.ToList();
            Session["ChucVu"] = ChucVu;
            var TrinhDo = db.tblTrinhDoHocVans.ToList();
            Session["TrinhDo"] = TrinhDo;
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(tblAccountNhanVien model, HttpPostedFile filePost, FormCollection collection)
        {
                string fileLocation = "";
                if (Request.Files["filePost"].ContentLength <= 0) { model.Image = ""; }
                //model.Image = "../assets/images/user_pic.jfif";
                ModelState["filePost"].Errors.Clear();
                if (ModelState.IsValid == true)
                {
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

                    tblAccount accItem = new tblAccount();

                    accItem.AccoutName = model.AccoutName;
                    accItem.CreatedDate = DateTime.Now;
                    accItem.CreatedUser = "ducthang";
                    accItem.DateIssued = model.DateIssued;
                    accItem.ModifiedDate = DateTime.Now;
                    accItem.ModifiedUser = "ducthang";
                    accItem.Password = model.Password;
                    accItem.Status = 1;
                    CECMSDbContext db = new CECMSDbContext();
                    db.tblAccounts.Add(accItem);
                    //db.SaveChanges();
                    tblNhanVien userItem = new tblNhanVien();
                    userItem.Account_ID = accItem.ID;
                    userItem.MA_NHANVIEN = model.MA_NHANVIEN;
                    userItem.HO_TEN = model.HO_TEN;
                    userItem.DIA_CHI = model.DIA_CHI;
                    userItem.QUE_QUAN = model.QUE_QUAN;
                    userItem.NGAY_SINH = model.NGAY_SINH;
                    userItem.Email = model.Email;
                    userItem.SO_DIENTHOAI = model.SO_DIENTHOAI;
                    //userItem.MA_PHONGBAN = model.MA_PHONGBAN;
                    //userItem.MA_CHUCVU = model.MA_CHUCVU;
                    //userItem.MA_TRINHDO = model.MA_TRINHDO;
                    userItem.GIOI_TINH = 1;
                    userItem.TRANGTHAI = 1;
                    userItem.MO_TA = model.MO_TA;
                    userItem.GHI_CHU = model.GHI_CHU;
                    userItem.ID = -1;
                    int iContent = fileLocation.IndexOf("Content");
                    if (iContent > 0)
                    {
                        userItem.Image = @"\" + fileLocation.Substring(iContent, fileLocation.Length - iContent);
                    }


                    db.tblNhanViens.Add(userItem);
                    db.SaveChanges();
                    return RedirectToAction("Index", "NhanVien");
                }
                else
                {
                    ModelState.AddModelError("", "Chưa nhập đầy đủ thông tin");
                }
                return View();

            
            
            

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            CECMSDbContext db = new CECMSDbContext();
            var item1 = db.tblNhanViens.Find(id);
            var item2 = db.tblAccounts.Find(item1.Account_ID);
            tblAccountNhanVien model = new tblAccountNhanVien();
            model.ID = item1.ID;
            model.AccoutName = item2.AccoutName;
            model.Account_ID = item2.ID;
            model.MA_NHANVIEN = item1.MA_NHANVIEN;
            model.DIA_CHI = item1.DIA_CHI;
            model.QUE_QUAN = item1.QUE_QUAN;
            model.Email = item1.Email;
            model.SO_DIENTHOAI = item1.SO_DIENTHOAI;
            model.NGAY_SINH = item1.NGAY_SINH;
            model.CreatedDate = DateTime.Now;
            model.CreatedUser = item2.CreatedUser;
            model.DateIssued = item2.DateIssued;
            model.MO_TA = item1.MO_TA;
            model.ModifiedDate = item2.ModifiedDate;
            model.ModifiedUser = item2.ModifiedUser;
            model.Password = item2.Password;
            //var GioiTinh = collection["customRadio"];
            //if (collection["customRadio"].ToString().Trim() != "Nam")
            //    model.GIOI_TINH = Convert.ToInt32(collection["customRadio"].ToString());
            //else
            //    model.GIOI_TINH = 0;
            model.GIOI_TINH = item1.GIOI_TINH;
            model.HO_TEN = item1.HO_TEN;
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(tblAccountNhanVien item, HttpPostedFile filePost, FormCollection collection)
        {


            CECMSDbContext db = new CECMSDbContext();
            var acc = db.tblAccounts.Find(item.Account_ID);

            acc.AccoutName = item.AccoutName;
            acc.CreatedDate = item.CreatedDate;
            acc.CreatedUser = item.CreatedUser;
            acc.DateIssued = item.DateIssued;
            acc.ModifiedDate = DateTime.Now;
            acc.ModifiedUser = "ducthang";
            acc.CreatedDate = DateTime.Now;
            acc.CreatedUser = "ducthang";
            acc.Password = item.Password;
            acc.Status = -1;
            //var uResult = db.SaveChanges();
            var user = db.tblNhanViens.Where(x => x.Account_ID == item.Account_ID).SingleOrDefault();
            user.HO_TEN = item.HO_TEN;
            user.NGAY_SINH = item.NGAY_SINH;
          
            var GioiTinh = collection["customRadio"];
            if (collection["customRadio"].ToString().Trim() != "Nam")
                item.GIOI_TINH = Convert.ToInt32(collection["customRadio"].ToString());
            else
                item.GIOI_TINH = 0;
            //user.Sex = item.Sex;
            user.TRANGTHAI = -1;
            user.DIA_CHI = item.DIA_CHI;
            user.QUE_QUAN = item.QUE_QUAN;
            user.Email = item.Email;
            user.SO_DIENTHOAI = item.SO_DIENTHOAI;
            string filelocation = "";
            if (Request.Files["filePost"].ContentLength > 0)
            {
                string fileExtenSion = System.IO.Path.GetExtension(Request.Files["filePost"].FileName);
                filelocation = Server.MapPath("~/Content/") + Request.Files["filePost"].FileName;

                if (System.IO.File.Exists(filelocation))
                {
                    System.IO.File.Exists(filelocation);
                }
                Request.Files["filePost"].SaveAs(filelocation);
                int icontent = filelocation.IndexOf("Content");
                if (icontent > 0)
                {
                    user.Image = @"\" + filelocation.Substring(icontent, filelocation.Length - icontent);
                }
                else
                {
                    user.Image = item.Image;
                }


                var uResult = db.SaveChanges();
                if (uResult >= 0)
                {
                    //SetAlert("success", "Cập nhật dữ liệu thành công");
                    return RedirectToAction("Index", "NhanVien");
                }
                else
                {
                    //SetAlert()
                    return View();
                }



            }
            return View();
        }
        //public ActionResult Details(tblAccountNhanVien model, int id)
        //{
        //    db = new CECMSDbContext();
        //    //var ID = Convert.ToInt32(id);
        //    model = db.tb.Find(id);
        //    return PartialView(model);
        //}
        public ActionResult Delete(tblNhanVien model, int id)
        {
            try
            {
                db = new CECMSDbContext();
                //var ID = Convert.ToInt32(id);
                var item = db.tblNhanViens.Find(id);
                if (item != null)
                {
                    db.tblNhanViens.Remove(item);
                    db.SaveChanges();
                }
                var item2 = db.tblAccounts.Find(id);
                if (item2 != null)
                {
                    db.tblAccounts.Remove(item2);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "NhanVien");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}