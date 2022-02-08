using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArch.Mvc.Pages
{
    public class CourseModel : PageModel
    {
        private readonly ICourseService courseService;

        public CourseModel(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        [BindProperty]
        public CourseViewModel CoursVm { get; set; }
        public void OnGet()
        {
            CoursVm = courseService.GetCourses();
        }
    }
}
