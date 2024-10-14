using Domain.Abstractions;
using Domain.Users.ValueObjects;
using System.Data;


namespace Domain.Users
{
    public class User : BaseEntity<int>, IScopeLifeTime
    {
        private User()
        {
        }

        public User(string userName, string password)
        {
            UserName = new(userName);
            Password = new(password);
        }

        public UserName UserName { get; set; }
        public Password Password { get; set; }


    }
}