using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;

namespace App.BL
{
    public interface IMessageService
    {
        void AddNewUser(string userName);

        void Send(string userName, Message message);

        Message[] GetMessagesByUserName(string userName);
    }
}
