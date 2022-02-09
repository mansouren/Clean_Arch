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
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public Check CheckUserEmailAndUserNameExist(string email, string username)
        {
            var emailValidation = repository.IsExistEmail(email.Trim().ToLower());
            var usernameValidation = repository.IsExistUserName(username);
            if (emailValidation && usernameValidation)
                return Check.EmailAndUserNameIsNotValid;
            else if (emailValidation)
                return Check.EmailIsNotValid;
            else if (usernameValidation)
                return Check.UserNameIsNotValid;
            else return Check.Ok;
        }

        public int RegisterUser(User user)
        {
            repository.AddUser(user);
            repository.SaveChanges();
            return user.Id;
        }
    }
}
