using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Contracts
{
   public interface ICourseRepositroy
    {
        IEnumerable<Course> GetCourses();
        Course GetCoursebyId(int id);
    }
}
