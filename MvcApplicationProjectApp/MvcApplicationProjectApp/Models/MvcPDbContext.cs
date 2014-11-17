using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplicationProjectApp.Models
{
    public class MvcPDbContext:DbContext
    {
        public DbSet<Department> DepartmentdDbSet { set; get; }
        public DbSet<Course> CourseDbSet { set; get; }
        public DbSet<Semester>SemesterDbSet { set; get; } 
    }
}