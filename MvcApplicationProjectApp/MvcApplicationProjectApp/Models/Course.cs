using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationProjectApp.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CrsCode { get; set; }
        public string CrsCradite { get; set; }
        public string CrsName { get; set; }
        public string CrsDescription { get; set; }
        public virtual Department Department { set; get; }
        public int DepartmentId { get; set; }
        public virtual Semester Semester { set; get; }
        public int SemesterId { get; set; }

    }
}