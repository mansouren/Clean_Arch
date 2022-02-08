using CleanArch.Domain.Contracts;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepositroy
    {
        private readonly UniversityDbContext dbContext;

        public CourseRepository(UniversityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Course GetCoursebyId(int id)
        {
            var res = dbContext.Courses.Find(id);
            return res;
        }

        public IEnumerable<Course> GetCourses()
        {
            var res = dbContext.Courses;
            return res;
        }
    }
}
