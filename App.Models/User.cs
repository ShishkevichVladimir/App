using System.Collections.Generic;

namespace App.Models
{
    public class User
    {
        public User()
        {
             Messages = new List<Message>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<Message> Messages { get; set; }
        
    }
}
