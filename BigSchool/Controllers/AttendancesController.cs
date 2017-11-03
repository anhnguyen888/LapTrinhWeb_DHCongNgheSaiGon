using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using BigSchool.Models;

namespace BigSchool.Controllers
{
    [Authorize]
    public class AttendancesController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public AttendancesController()
        {
            dbContext = new ApplicationDbContext();
        }

        public ActionResult Attend(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var userId = User.Identity.GetUserId();

            //kiem tra da dang ky khoa hoc hay chua?
            var isAttend = dbContext.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == id);

            //Neu ma chua dang ky
            if (!isAttend)
            {
                var attendance = new Attendance()
                {
                    CourseId = (int)id,
                    AttendeeId = userId
                };

                dbContext.Attendances.Add(attendance);
                dbContext.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}