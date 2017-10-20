using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BigSchool.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;

            //chuyen gia tri nguoi dung nhap (value) ve kieu ngay thang
            //Neu chuyen thanh cong --> luu vao bien dateTime, va isValid = true
            //nguoc lai neu chuyen khong thanh cong thi isValid = false
            var isValid = DateTime.TryParseExact(value.ToString(),
                "dd/M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            //if(isValid == true && dateTime > DateTime.Now)
            //{
            //    return true;
            //}
            //return false;

            //Neu ngay nguoi dung nhap vao chuyen thanh cong sang kieu ngay thang (isValid = true) Va ngay nhap vao lon hon ngay hien tai thi tra ve TRUE, nguoc lai tra ve FALSE
            return (isValid && dateTime > DateTime.Now) ? true : false;
        }
    }
}