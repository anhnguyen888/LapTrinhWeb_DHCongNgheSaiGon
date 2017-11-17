using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using BigSchool.ViewModels;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext dbContext;

        public HomeController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            //Linq, Lamda
            var listCourses = dbContext.Courses
                                .Include(l => l.Lecturer)
                                .Include(c => c.Category)
                                .Where(c => c.DateTime > DateTime.Now && c.LecturerId != userId).ToList();

            var listAttended = dbContext.Attendances
                                .Where(a => a.AttendeeId == userId)
                                .Select(a => a.CourseId);

            var viewModel = new CourseHomePageViewModel()
            {
                UpCommingCourses = listCourses,
                AttendedCourses = listAttended,
                ShowAction = User.Identity.IsAuthenticated
            };
           
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}