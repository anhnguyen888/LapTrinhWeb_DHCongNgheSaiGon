using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigSchool.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Nhieu khoa hoc
        public ICollection<Course> Courses { get; set; }
    }
}