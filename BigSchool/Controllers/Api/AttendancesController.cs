using BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BigSchool.DTOs;

namespace BigSchool.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext dbContext;

        public AttendancesController()
        {
            dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO attendanceDTO)
        {
            //Lay user id
            var userId = User.Identity.GetUserId();

            //Kiem tra da dang ky tham du khoa hoc hay chua
            var isAttend = dbContext.Attendances.Any(a=>a.CourseId == attendanceDTO.courseId && a.AttendeeId == userId);

            if (isAttend)
                return BadRequest("Already Exist!");
            
            //Process attend
            var attendance = new Attendance()
            {
                AttendeeId = userId,
                CourseId = attendanceDTO.courseId
            };

            dbContext.Attendances.Add(attendance);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(AttendanceDTO attendanceDTO)
        {
            var userId = User.Identity.GetUserId();
            var attendedCourse = dbContext.Attendances.Where(a => a.CourseId == attendanceDTO.courseId && a.AttendeeId == userId).FirstOrDefault();

            if (attendedCourse != null)
            {
                dbContext.Attendances.Remove(attendedCourse);
                dbContext.SaveChanges();
            }
            else
            {
                return BadRequest("Not Attended!");
            }
            return Ok();
        }

    }
}
