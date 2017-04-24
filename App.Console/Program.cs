using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BL;
using App.Models;

namespace App.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            IMessageService service = new MessageService(new Repository.Repository());
            service.AddNewUser("user");
            service.Send("user", new Message
            {
                Text = "dfds"
            });


        }
    }
}
