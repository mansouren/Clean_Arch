using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Contracts
{
    public interface IUserRepository
    {
        bool IsExistUser(string email, string password);

        void AddUser(User user);
        bool IsExistUserName(string username);
        bool IsExistEmail(string email);
        void SaveChanges();
    }
}
