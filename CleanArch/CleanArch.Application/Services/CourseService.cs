using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Contracts;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepositroy courseRepositroy;

        public CourseService(ICourseRepositroy courseRepositroy)
        {
            this.courseRepositroy = courseRepositroy;
        }

        public Course GetCourseById(int id)
        {
            return courseRepositroy.GetCoursebyId(id);

        }

        public CourseViewModel GetCourses()
        {
            return new CourseViewModel
            {
                Courses = courseRepositroy.GetCourses()
            };
        }
    }
}
