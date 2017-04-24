using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using App.EF;
using App.Models;

namespace App.Repository
{
    public class Repository : IRepository
    {
        private readonly AppEfContext _context;

        public Repository()
        {
            _context = new AppEfContext();
        }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }

        public User GetUserByName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            Expression<Func<User, bool>> getUserByName = usr => usr.Name.Equals(userName, StringComparison.InvariantCultureIgnoreCase);

            return _context.Users.FirstOrDefault(getUserByName);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        
        public void AddMessage(string userName, Message message)
        {
            var user = GetUserByName(userName);
           
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
