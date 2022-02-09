using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
   public interface IUserService
    {
        Check CheckUserEmailAndUserNameExist(string email,string username);
      
        int RegisterUser(User user);
    }
}
