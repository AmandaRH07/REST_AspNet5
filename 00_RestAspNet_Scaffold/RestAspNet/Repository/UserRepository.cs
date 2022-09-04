using RestAspNet.Data.Value_Object;
using RestAspNet.Model;
using RestAspNet.Model.Context;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace RestAspNet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public UserRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public User ValidadeCredentials(UserVO user)
        {
            var pass = ComputerHash(user.Password, new SHA256CryptoServiceProvider());
            return _sqlServerContext.Users.FirstOrDefault(u => (u.UserName == user.UserName) && u.Password == pass);
        }

        public User ValidateCredentials(string userName)
        {
            return _sqlServerContext.Users.SingleOrDefault(u => u.UserName == userName);
        }
        public bool RevokeToken(string userName)
        {
            var user = _sqlServerContext.Users.SingleOrDefault(u => u.UserName == userName);

            if (user is null) return false;
            user.RefreshToken = null;

            _sqlServerContext.SaveChanges();

            return true;
        }

        public User UpdateUserInfo(User user)
        {
            if (_sqlServerContext.Users.Any(p => p.Id.Equals(user.Id))) return null;


            var result = _sqlServerContext.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _sqlServerContext.Entry(result).CurrentValues.SetValues(user);
                    _sqlServerContext.SaveChanges();
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result; 
        }

        private string ComputerHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
