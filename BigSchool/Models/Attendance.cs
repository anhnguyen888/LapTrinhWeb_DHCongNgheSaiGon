using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigSchool.Models
{
    public class Attendance
    {
        //User Info
        public ApplicationUser Attendee { get; set; }
        [Key]
        [Column(Order = 1)]
        public string AttendeeId { get; set; }

        //Course Info
        public Course Course { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CourseId { get; set; }
    }
}