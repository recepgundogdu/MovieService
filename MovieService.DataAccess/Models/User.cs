using System.Collections.Generic;

namespace MovieService.DataAccess.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Rights { get; set; }
    }
}
