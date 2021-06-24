using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTTUniversity.Models;

namespace UTTUniversity.Areas.AdminThuVien.Controllers
{
    public class HomeController : Controller
    {
        CECMSDbContext db;
        // GET: Admin/Home
        public ActionResult Index( int id)
        {
            
            db = new CECMSDbContext();
            var model = db.tblAccounts.Where(x => x.ID == id).FirstOrDefault();
            Session["accountAdmin"] = model;

            var model1 = db.tblNhanViens.Where(x => x.Account_ID == model.ID).FirstOrDefault();
            Session["user"] = model1;
            
            return View();
        }

        public JsonResult JGetChart1()
        {
            db = new CECMSDbContext();
            int kho = db.tblChiTietPhieuNhaps.Sum(x => x.SO_LUONG );
            int sach = db.tblSaches.Where(x => x.TRANG_THAI == 1).Sum(x => x.SO_LUONG);
            var model = db.tblMuonTras.Where(x => x.TRANG_THAI == 1).ToList();
            int muon = 0;
            int quahan = 0;
            foreach (var item in model)
            {
                if (item.GHI_CHU.Equals("Quá hạn"))
                {
                    quahan = quahan + item.SO_LUONG;
                }
                else if(item.GHI_CHU.Equals("Đang mượn"))
                {
                    muon = muon + item.SO_LUONG;
                }
            }
            List<DataAmChart> result = new List<DataAmChart>();
            DataAmChart dt1 = new DataAmChart();
            dt1.country = "Kho sách";
            dt1.litres = kho - sach - muon;
            result.Add(dt1);
            DataAmChart dt2 = new DataAmChart();
            dt2.country = "Sách trên kệ";
            dt2.litres =  sach;
            result.Add(dt2);
            DataAmChart dt3 = new DataAmChart();
            dt3.country = "Đang mượn";
            dt3.litres =  muon;
            result.Add(dt3);
            DataAmChart dt4 = new DataAmChart();
            dt4.country = "Quá hạn";
            dt4.litres = quahan;
            result.Add(dt4);

            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        public class DataAmChart
        {
            public string country { get; set; }

            public int litres { get; set; }
        }
    }
}