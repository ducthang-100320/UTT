using System.Web.Mvc;

namespace ThuVienTruongHoc.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminAdminThuVien_default",
                "AdminThuVien/{controller}/{action}/{id}",
               new { action = "Index", controller = "Home", id = UrlParameter.Optional },
               new[] { "UTTUniversity.Areas.AdminThuVien.Controllers" }
            );
        }
    }
}