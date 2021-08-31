using MovieService.DataAccess.Models;
using System.Collections.Generic;

namespace MovieService.DataAccess
{
    public static class UserRepo
    {
        public static List<User> Users
        {
            get
            {
                return new List<User>
                {
                    new User{ Id=1, Username= "URead", Password = "123", Rights = new List<string>{ "Read" } },
                    new User{ Id=1, Username= "UWrite", Password = "321", Rights = new List<string>{ "Read","Write" } }
                };

            }
            private set { Users = value; }
        }
    }
}
