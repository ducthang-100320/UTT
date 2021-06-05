using System.Web.Mvc;

namespace UTTUniversity.Areas.AdminThuVien
{
    public class AdminThuVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminThuVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminThuVien_default",
                "AdminThuVien/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional },
                new[] { "UTTUniversity.Areas.AdminThuVien.Controllers" }
            );
        }
    }
}