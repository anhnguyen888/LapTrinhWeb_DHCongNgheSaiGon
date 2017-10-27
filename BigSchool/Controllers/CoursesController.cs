using BigSchool.Models;
using BigSchool.ViewModels;
using System.Web.Mvc;
using System;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Data.Entity;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
        private ApplicationDbContext dbContext;

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
                    DateTime = courseViewModel.GetDateTime(),
                    CategoryId = courseViewModel.CategoryId,
                    LecturerId = userId
                };
                //luu khoa hoc
                dbContext.Courses.Add(course);
                dbContext.SaveChanges();
                //Chuyen ve trang quan ly khoa hoc
                return RedirectToAction("ManageCourses");
            }
            catch (System.Exception ex)
            {
                //Write log
                throw ex;
            }
        }

        [Authorize]
        public ActionResult ManageCourses()
        {
            try
            {
                var useId = User.Identity.GetUserId();
                //linq using lamda
                var courses = dbContext.Courses
                    .Include(l => l.Lecturer)
                    .Include(c => c.Category)
                    .Where(c => c.LecturerId == useId);
                return View(courses);
            }
            catch (Exception ex)
            {
                //write log
                throw ex;
            }
        }
    }
}