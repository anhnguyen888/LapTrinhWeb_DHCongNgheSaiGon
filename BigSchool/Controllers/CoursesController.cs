using BigSchool.Models;
using BigSchool.ViewModels;
using System.Web.Mvc;
using System.Data.Entity;

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
                ModelState.AddModelError("", "Loi");
                courseViewModel.Categories = dbContext.Categories;
                return View(courseViewModel);
            }
            return View();
        }
    }
}