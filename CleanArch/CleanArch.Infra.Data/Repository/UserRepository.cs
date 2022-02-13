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
    public class UserRepository : IUserRepository
    {
        private readonly UniversityDbContext dbContext;

        public UserRepository(UniversityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void AddUser(User user)
        {
            dbContext.User.Add(user);
        }

        public bool IsExistEmail(string email)
        {
            return dbContext.User.Any(u => u.Email == email);
        }

        public bool IsExistUser(string email, string password)
        {
           return dbContext.User.Any(u => u.Email == email && u.Password == password);
        }

        public bool IsExistUserName(string username)
        {
            return dbContext.User.Any(u => u.Username == username);
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
