using MovieService.Core.Models.Results;
using MovieService.DataAccess;
using MovieService.DataAccess.Models;
using System;

namespace MovieService.Core.Business
{
    public class UserService : IUserService
    {
        public IDataResult<User> GetUser(string UserName, string Password)
        {
            try
            {
                var result = UserRepo.Users.Find(x => x.Username == UserName && x.Password == Password);
                if (result!=null)
                {
                    return new SuccessDataResult<User>(result);
                }

                return new ErrorDataResult<User>();
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<User>(ex.Message);
            }
        }
    }

    public interface IUserService
    {
        IDataResult<User> GetUser(string UserName, string Password);
    }
}
