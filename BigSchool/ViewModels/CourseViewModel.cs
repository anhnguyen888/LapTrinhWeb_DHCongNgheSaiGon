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
        public string Place { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        [Display(Name ="Category")]
        public int CategoryId { get; set; }
    }
}