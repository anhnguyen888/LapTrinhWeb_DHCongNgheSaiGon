using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Place { get; set; }

        public DateTime DateTime { get; set; }

        //danh muc
        public int CategoryId  { get; set; }

        public Category Category { get; set; }

        //Giang vien
        public string LecturerId { get; set; }

        public ApplicationUser Lecturer { get; set; }

    }
}