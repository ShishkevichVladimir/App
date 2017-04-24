using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using Microsoft.Win32;

namespace App.Repository
{
    public interface IRepository
    {
        void AddUser(User user);
        User GetUserByName(string userName);
        List<User> GetAllUsers();
        
        void AddMessage(string userName, Message message);

        int Commit();
    }
}
