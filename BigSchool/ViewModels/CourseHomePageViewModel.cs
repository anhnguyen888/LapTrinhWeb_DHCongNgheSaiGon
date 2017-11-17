using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CourseHomePageViewModel
    {
        public IEnumerable<Course> UpCommingCourses { get; set; }

        public IEnumerable<int> AttendedCourses { get; set; }

        public bool ShowAction { get; set; }
    }
}