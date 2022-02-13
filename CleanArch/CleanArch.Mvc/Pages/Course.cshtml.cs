using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CleanArch.Mvc.Pages
{
    [Authorize]
    public class CourseModel : PageModel
    {
        private readonly ICourseService courseService;

        public CourseModel(ICourseService courseService)
        {
            this.courseService = courseService;
        }
        [BindProperty]
        public Course Course { get; set; }
        public IActionResult OnGet(int id)
        {
            Course = courseService.GetCourseById(id);
            if (Course == null) return NotFound();
            return Page();
        }
    }
}
