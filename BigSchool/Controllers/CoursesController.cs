using BigSchool.Models;
using BigSchool.ViewModels;
using System.Web.Mvc;
using System.Data.Entity;
using System;
using Microsoft.AspNet.Identity;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CoursesController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new CourseViewModel()
            {
                Categories = dbContext.Categories
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CourseViewModel courseViewModel)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error!");
                courseViewModel.Categories = dbContext.Categories;
                return View(courseViewModel);
            }
            //Lay thong tin Id cua nguoi dang tao khoa hoc (chinh la Giang Vien)
            var userId = User.Identity.GetUserId();
            //Du lieu hop le 
            //Luu vao Datbase

            try
            {
                //Convert courseViewModel To Course
                var course = new Course()
                {
                    Place = courseViewModel.Place,
                    DateTime = DateTime.Parse(courseViewModel.Date + " " + courseViewModel.Time),
                    CategoryId = courseViewModel.CategoryId,
                    LecturerId = userId
                };
                //luu khoa hoc
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
                //Chuyen ve trang quan ly khoa hoc
                return RedirectToAction("CoursesManagement");
            }
            catch (System.Exception ex)
            {
                //Write log
                throw ex;
            }
        }
    }
}