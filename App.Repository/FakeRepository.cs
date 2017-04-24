using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.Repository
{
    public class FakeRepository : IRepository
    {
        private readonly List<User> _users;

        public FakeRepository()
        {
            var user = new User
            {
                Name = "bob"
            };

            user.Messages = new List<Message>()
            {
                new Message {  Text = "1" },
                new Message {  Text = "2" },
                new Message {  Text = "3" },
                new Message {  Text = "4" },
                new Message {  Text = "5" },
            };

            _users = new List<User>
            {
                user,
                new User { Id = 101, Name  = "john" },
                new User { Id = 102, Name  = "bob2" },
            };
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User GetUserByName(string userName)
        {
            return _users.SingleOrDefault(usr => usr.Name.Equals(userName, StringComparison.InvariantCultureIgnoreCase));
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public void AddMessage(string userName, Message message)
        {
            var uesr = GetUserByName(userName);
            uesr.Messages.Add(message);
        }

        public int Commit()
        {
            return 1;
        }
    }
}
