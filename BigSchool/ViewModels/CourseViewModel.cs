using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BigSchool.ViewModels
{
    public class CourseViewModel
    {
        [StringLength(100, ErrorMessage ="Place less than 100 characters")]
        [Required(ErrorMessage ="Place is Required")]
        public string Place { get; set; }

        [FutureDate]
        [Required(ErrorMessage = "Date is Required")]
        public string Date { get; set; }

        [ValidTime]
        [Required(ErrorMessage = "Time is Required")]
        public string Time { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        internal DateTime GetDateTime()
        {
            DateTime dateTime;
            //chuyen gia tri nguoi dung nhap (value) ve kieu ngay thang
            //Neu chuyen thanh cong --> luu vao bien dateTime, va isValid = true
            //nguoc lai neu chuyen khong thanh cong thi isValid = false
            var isValid = DateTime.TryParseExact(Date,
                "dd/M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return DateTime.Parse(string.Format("{0} {1}", dateTime.ToShortDateString(), Time));
        }
    }
}