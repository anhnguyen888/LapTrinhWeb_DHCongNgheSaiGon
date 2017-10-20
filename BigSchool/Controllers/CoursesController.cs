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
    }
}