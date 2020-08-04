using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public interface IUserService
    {
        LoginToken Authenticate(string username, string password);
        User GetById(int id);
        void Create(UserRegistration user);
        void Update(User user, string password = null);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        public LoginToken Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Create(UserRegistration user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}
