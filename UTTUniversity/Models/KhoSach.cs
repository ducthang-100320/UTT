using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UTTUniversity.Models
{
    public class KhoSach
    {
        public int ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NGAY_NHAP { get; set; }

        public string MA_NXB { get; set; }

        public string TEN_SACH { get; set; }

        public string TEN_THELOAI { get; set; }

        public int SO_LUONG { get; set; }

        public int TRANG_THAI { get; set; }

       
        public string GHI_CHU { get; set; }
    }
}