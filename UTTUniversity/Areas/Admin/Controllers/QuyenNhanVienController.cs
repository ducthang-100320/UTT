using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.Admin.Controllers
{
    public class QuyenNhanVienController : Controller
    {
        #region Variables
        CECMSDbContext db;
        #endregion
        // GET: Admin/QuyenNhanVien
        public ActionResult Index()
        {
            SetTable();
            return View();
        }
        public JsonResult SaveData(string ID, String Choice)
        {
            //Thực hiện cập nhật dữ liệu
            var strID = ID.Replace("chk_", "").Replace(" ", "").Trim();
            var arrID = strID.Split('_');
            var UserID = arrID[0].ToString();
            var RoleID = arrID[1].ToString();
            db = new CECMSDbContext();
            if (Choice.ToUpper() == "TRUE")
            {
                //Thực hiện ghi dữ liệu
                var item = new tblNVIEN_QUYEN();
                item.ID = -1;
                item.UserID = Convert.ToInt32(RoleID);
                item.RoleID = UserID;

                db.tblNVIEN_QUYEN.Add(item);
                var result = db.SaveChanges();
                if (result > 0)
                {
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                //Xóa dữ liệu
                var uID = Convert.ToInt32(RoleID);
                var item = db.tblNVIEN_QUYEN.Where(x => x.RoleID == UserID && x.UserID == uID).SingleOrDefault();
                var Result = db.tblNVIEN_QUYEN.Remove(item);
                db.SaveChanges();
                if (Result != null)
                {
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }
            }
            return Json("OK", JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            SetTable();

            //Xóa dữ liệu
            for (int i = 1; i < collection.AllKeys.Count(); i++)
            {
                if (collection.AllKeys[i].Contains('_') == true)
                {
                    var arr = collection.AllKeys[i].ToString().Split('_');
                    string MA_NVIEN = arr[2].ToString().Trim();
                }
            }
            //Ghi dữ liệu
            string resInsert = "";
            for (int i = 1; i < collection.AllKeys.Count(); i++)
            {
                if (collection.AllKeys[i].Contains("_") == true)
                {
                    var arr = collection.AllKeys.ToString().Split('_');
                    string MA_QUYEN = arr[1].ToString().Trim();
                    string MA_NVIEN = arr[2].ToString().Trim();
                }
            }

            if (resInsert == "OK")
            {
                //SetAlert("Success", "Thêm mới dữ liệu thành công");
                return RedirectToAction("Index", "QuyenNhanVien");
            }
            else
            {
                //SetAlert("Error", "Lỗi trong quá trình thêm dữ liệu:" + resInsert);
                return View();
            }
        }

        #region Public funtions
        private void SetTable()
        {
            try
            {
                db = new CECMSDbContext();
                var lstRole = db.tblQuyens.ToList();
                Session["Role"] = lstRole;

                var lstUser = db.tblNhanViens.ToList();
                Session["Teacher"] = lstUser;

                var lstQuyen = (from a in db.tblNhanViens
                                join b in db.tblNVIEN_QUYEN
                                on a.ID equals b.UserID
                                where a.TRANGTHAI == 1
                                select new
                                {
                                    ID = a.ID,
                                    HO_TEN = a.HO_TEN,
                                    RoleID = b.RoleID,
                                }).ToList();
                List<tblNVIEN_QUYEN> iUserRole = new List<tblNVIEN_QUYEN>();
                foreach (var item in lstQuyen)
                {
                    tblNVIEN_QUYEN iNew = new tblNVIEN_QUYEN();
                    iNew.ID = item.ID;
                    iNew.RoleID = item.RoleID;
                    iNew.UserID = item.ID;
                    iUserRole.Add(iNew);
                }
                Session["TeacherRole"] = iUserRole;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                throw;
            }
        }
        #endregion

    }
}
