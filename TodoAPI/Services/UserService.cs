using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Helpers;
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
        private TodoContext _context;
        private readonly AppSettings appSettings;

        public LoginToken Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Create(UserRegistration user)
        {
            if (user.Password != user.PasswordConfirmation) { throw new Exception("Passwords do not match"); }
            if (user.Password == user.Username) { throw new Exception("Password cannot be the same as your username"); }
            // TODO: Password Complexity Check
            if (string.IsNullOrWhiteSpace(user.Password)) { throw new Exception("Password is required"); }
            if (string.IsNullOrWhiteSpace(user.Username)) { throw new Exception("Username is required"); }

            if (_context.Users.Any(x => x.Username == user.Username)) { throw new Exception("Username is already taken"); }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            _context.Users.Add(new User
            {
                Username = user.Username,
                DisplayName = user.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User user, string password = null)
        {
            throw new NotImplementedException();
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) { throw new ArgumentNullException("password"); }
            if (string.IsNullOrWhiteSpace(password)) { throw new ArgumentException("Value cannot be empty or whitespace.", "password"); }
            
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
