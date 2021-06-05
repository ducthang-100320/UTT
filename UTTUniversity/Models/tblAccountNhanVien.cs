using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTTUniversity.Models
{
    public class tblAccountNhanVien
    {
        public int ID { get; set; }

        public string AccoutName { get; set; }

        public string Password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateIssued { get; set; }

        public int Status { get; set; }

        public DateTime? CreatedDate { get; set; }


        public string CreatedUser { get; set; }

        public DateTime? ModifiedDate { get; set; }


        public string ModifiedUser { get; set; }


        public string MA_NHANVIEN { get; set; }

        public int Account_ID { get; set; }

        public string HO_TEN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NGAY_SINH { get; set; }

        public int GIOI_TINH { get; set; }


        public string Email { get; set; }


        public string SO_DIENTHOAI { get; set; }


        public string QUE_QUAN { get; set; }


        public string DIA_CHI { get; set; }


        public string Image { get; set; }


        public string MA_PHONGBAN { get; set; }


        public string MA_CHUCVU { get; set; }


        public string MA_TRINHDO { get; set; }

        public int TRANGTHAI { get; set; }


        public string MO_TA { get; set; }


        public string GHI_CHU { get; set; }
    }
}