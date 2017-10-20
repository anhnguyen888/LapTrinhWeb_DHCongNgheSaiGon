using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Time is Required")]
        public string Time { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        [Required(ErrorMessage = "Category is Required")]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
    }
}